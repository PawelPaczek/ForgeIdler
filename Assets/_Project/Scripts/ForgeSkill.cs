using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ForgeSkill", menuName = "ScriptableObjects/ForgeSkill", order = 1)]
public class ForgeSkill : ScriptableObject
{
    public int level;
    public string name;
    public string description;
    public List<int> levelUpCost;
}
