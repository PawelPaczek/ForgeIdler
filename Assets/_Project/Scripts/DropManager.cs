using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class DropManager : MonoBehaviour
{
    [SerializeField] private DropSystem dropSystem;
    [SerializeField] private ItemManager itemManager;


    public void SpawnItems()
    {
        List<Item> drawnItems = dropSystem.GetRandomItem();
        SetUpItemAnimation(drawnItems);
    }

    private void SetUpItemAnimation(List<Item> drawnItems)
    {
        itemManager.SetItems(drawnItems);
    }
    


}