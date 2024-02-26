using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class ItemManager : MonoBehaviour
{
    [Inject] private ItemViewPool viewPool;
    [Inject] private CurrencyManager currencyManager;
    [SerializeField] private ItemDropAnimationDatabase itemDropAnimationDatabase;

    public void SpawnItems(List<Item> drawnItems)
    {
        for (int i = 0; i < drawnItems.Count; i++)
        {
            ItemView newItemView = viewPool.GetItemView(Vector3.zero, this.transform, drawnItems[i].GetItemSprite());
            SetItemDropAnimation(drawnItems[i], newItemView, i);
        }
    }

    private void SetItemDropAnimation(Item item, ItemView itemView, int itemIndex)
    {
        Vector3[] path = new Vector3[]
        {
            itemDropAnimationDatabase.GetWaypoints(itemIndex)[0],
            itemDropAnimationDatabase.GetWaypoints(itemIndex)[1],
            itemDropAnimationDatabase.GetWaypoints(itemIndex)[2],
        };

        itemView.transform.localScale = Vector3.zero;
        itemView.transform.DOLocalPath(path, 1.5f).SetEase(Ease.Linear).SetOptions(false)
            .OnComplete(() => OnPathComplete(item, itemView))
            .OnWaypointChange((waypointIndex) => OnWaypointReached(waypointIndex, itemIndex, itemView));
    }

    void OnWaypointReached(int waypointIndex, int itemIndex, ItemView itemView)
    {
        if (waypointIndex == 0)
        {
            itemView.transform.DOScale(itemDropAnimationDatabase.GetScale(itemIndex)[0], 0.5f).SetEase(Ease.OutQuad);
        }
        else if (waypointIndex == 1)
        {
            itemView.transform.DOScale(itemDropAnimationDatabase.GetScale(itemIndex)[1], 1.5f).SetEase(Ease.OutQuad);
        }
    }

    void OnPathComplete(Item item, ItemView itemView)
    {
        itemView.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.OutQuad).OnComplete(() => SellItem(item, itemView));
    }

    private void SellItem(Item item, ItemView itemView)
    {
        currencyManager.AddCurrency(item.GetPrice());
        viewPool.ReturnItemView(itemView);
    }
}