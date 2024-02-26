using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ForgeSkill", menuName = "ScriptableObjects/ForgeSkill", order = 1)]
public class ForgeSkill : ScriptableObject,IForgeSkill
{
    [SerializeField] private int level;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private SkillType skillType;
    [SerializeField] private List<int> levelUpCost;

    public enum SkillType
    {
        ForgeItemAmount,
        ForgingAutomatization,
        ForgingLevel,
        ForgingSpeed
    }
    
    public SkillType GetSkillType()
    {
      return skillType;
    }

    public int GetLevel()
    {
        return level;
    }

    public void AddLevel()
    {
        level++;
    }
    
    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public List<int> GetLevelCost()
    {
        return levelUpCost;
    }

}
