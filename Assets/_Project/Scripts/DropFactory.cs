using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

[CreateAssetMenu(fileName = "DropFactory", menuName = "ScriptableObjects/DropFactory")]
public class DropFactory : ScriptableObject
{
    public List<Item> itemsPool;
    [SerializeField] private ForgeSkill forgeItemAmount;
    [SerializeField] private ForgeSkill forgingLevel;

    public List<Item> GetRandomItem()
    {
        Random random = new Random();
        List<Item> drawnItems = new List<Item>();

        for (int i = 0; i < forgeItemAmount.GetLevel(); i++)
        {
            int los = random.Next(100);
            if (forgeItemAmount.GetLevel()<=1)
            {
                los = 1;
            }
            
            foreach (var item in DrawItemsFromPool())
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
    
    private List<Item> DrawItemsFromPool()
    {
        List<Item> conditionMeetingItems = new List<Item>();;

        for (int i = 0; i < itemsPool.Count; i++)
        {
            if (forgingLevel.GetLevel() >= itemsPool[i].GetLevelRequirement())
            {
                conditionMeetingItems.Add(itemsPool[i]);
            }
        }
        
        return conditionMeetingItems;
    }
}
