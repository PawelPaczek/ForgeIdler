using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViewPool : MonoBehaviour
{
    public ItemView itemViewPrefab;
    public int poolSize = 10;
    
    private List<ItemView> itemViews;
    
    public void InitializePool(ItemView squereGateToSet,int size)
    {
        itemViews = new List<ItemView>();
        itemViewPrefab = squereGateToSet;
        poolSize = size;
        
        for (int i = 0; i < poolSize; i++)
        {
            ItemView squereGate = Instantiate(itemViewPrefab);
            squereGate.OnDespawn();
            itemViews.Add(squereGate);
        }
    }
    
    public ItemView GetItemView(Vector3 startPosition,Transform parent, Sprite itemSprite)
    {
        foreach (ItemView itemView in itemViews)
        {
            if (!itemView.gameObject.activeInHierarchy)
            {
                itemView.OnSpawn(startPosition,parent,itemSprite);
                return itemView;
            }
        }

        ItemView newItemView = Instantiate(itemViewPrefab);
        itemViews.Add(newItemView);
        newItemView.OnSpawn(startPosition,parent,itemSprite);
        return newItemView;
    }

    public void ReturnItemView(ItemView squereGate)
    {
        squereGate.OnDespawn();
    }
}
