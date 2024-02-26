using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IForgeSkill
{
    public int GetLevel();
    public void AddLevel();
    public string GetName();
    public string GetDescription();
    public List<int> GetLevelCost();
}
