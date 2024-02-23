using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class DropManager : MonoBehaviour
{
    public List<Item> itemsPool;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private ForgingSkillsManager forgingSkillsManager;

    public void SpawnItems()
    {
        int itemsAmountToPool = forgingSkillsManager.forgeItemAmount.level;
        List<Item> conditionMeetingItems = DrawItemsFromPool();
        List<Item> drawnItems = GetRandomItem(itemsAmountToPool,conditionMeetingItems);
        SetUpItemAnimation(drawnItems);
    }

    private void SetUpItemAnimation(List<Item> drawnItems)
    {
        itemManager.SetItems( drawnItems);
    }
    
    private List<Item> DrawItemsFromPool()
    {
        List<Item> conditionMeetingItems = new List<Item>();;

        for (int i = 0; i < itemsPool.Count; i++)
        {
            if (forgingSkillsManager.forgingLevel.level >= itemsPool[i].GetLevelRequirement())
            {
                conditionMeetingItems.Add(itemsPool[i]);
            }
        }
        
        return conditionMeetingItems;
    }
    
    public List<Item> GetRandomItem(int itemsAmountToPool,List<Item> conditionMeetingItems)
    {
        Random random = new Random();
        List<Item> drawnItems = new List<Item>();

        for (int i = 0; i < itemsAmountToPool; i++)
        {
            int los = random.Next(100);
            int cumulativeChance = 0;

            foreach (var item in conditionMeetingItems)
            {

                if (los < item.GetChanceToDrop())
                {
                    drawnItems.Add(item);
                    break;
                }
            }
        }

        return drawnItems;
    }

}