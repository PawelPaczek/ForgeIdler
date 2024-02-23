using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
  public Sprite GetItemSprite();
  public int GetPrice();
  public int GetLevelRequirement();
  public int GetChanceToDrop();
}
