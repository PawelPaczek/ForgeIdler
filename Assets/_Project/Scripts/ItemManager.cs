using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private  List<GameObject> itemsObjects;
    [SerializeField] private  List<SpriteRenderer> itemsSpriteRenderer;
    [SerializeField] private ForgingSkillsManager forgingSkillsManager;
    [SerializeField] private CurrencyManager currencyManager;

    private void Start()
    {
        SetUpForge();
    }

    public void LevelUpForge()
    {
        SetUpForge();
    }
    
    private void SetUpForge()
    {
        for (int i = 0; i < forgingSkillsManager.forgeItemAmount.level; i++)
        {
            itemsObjects[i].SetActive(true);
        }
    }

    public void SetItems(List<Item> drawnItems)
    {
        for (int i = 0; i < drawnItems.Count; i++)
        {
            itemsSpriteRenderer[i].sprite = drawnItems[i].GetItemSprite();
            SellItem(drawnItems[i]);
        }
    }

    private void SellItem(Item item)
    {
        currencyManager.AddCurrency(item.GetPrice());
    }
}
