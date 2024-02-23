using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> itemsObjects;
    [SerializeField] private List<SpriteRenderer> itemsSpriteRenderer;
    [Inject] [SerializeField] private SkillDatabase skillDatabase;
    [Inject] [SerializeField] private CurrencyManager currencyManager;

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
        ForgeSkill forgingForgeItemAmountSkill = skillDatabase.GetSpecifiedSkill(ForgeSkill.SkillType.ForgeItemAmount);
        if (forgingForgeItemAmountSkill == null) return;

        for (int i = 0; i < forgingForgeItemAmountSkill.GetLevel(); i++)
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