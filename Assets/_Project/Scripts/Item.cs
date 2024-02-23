using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject,IItem
{
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private int itemPrice;
    [SerializeField] private int levelRequirement;
    [SerializeField] private int chanceToDrop;
    
    public Sprite GetItemSprite()
    {
      return  itemSprite;
    }
    
    public int GetPrice()
    {
      return  itemPrice;
    }

    public int GetLevelRequirement()
    {
        return levelRequirement;
    }

    public int GetChanceToDrop()
    {
        return chanceToDrop;
    }
}

