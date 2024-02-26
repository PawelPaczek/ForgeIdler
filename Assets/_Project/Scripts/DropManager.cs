using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class DropManager : MonoBehaviour
{
    [SerializeField] private DropFactory dropFactory;
    [SerializeField] private ItemManager itemManager;


    public void DrawItems()
    {
        List<Item> drawnItems = dropFactory.GetRandomItem();
        if (drawnItems.Count > 0)
        {
            GetItemsFromPool(drawnItems);
        }
    }

    private void GetItemsFromPool(List<Item> drawnItems)
    {
        itemManager.SpawnItems(drawnItems);
    }
}