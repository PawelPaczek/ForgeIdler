using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class DropManager : MonoBehaviour
{
    [SerializeField] private DropFactory dropFactory;
    [SerializeField] private ItemManager itemManager;


    public void SpawnItems()
    {
        List<Item> drawnItems = dropFactory.GetRandomItem();
        SetUpItemAnimation(drawnItems);
    }

    private void SetUpItemAnimation(List<Item> drawnItems)
    {
        itemManager.SetItems(drawnItems);
    }
    


}