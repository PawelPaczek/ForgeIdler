using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgingSkillsManager : MonoBehaviour
{
    private List<GameObject> itemSlots;
    
    public ForgeSkill forgeItemAmount;
    public ForgeSkill forgingLevel;
    public ForgeSkill forgingSpeed;
    public ForgeSkill forgingAutomatization;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private HammerController hammerController;
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private List<ForgeSkill> forgeSkills;
    [SerializeField] private List<SkillView> skillViews;

    private void Start()
    {
        for (int i = 0; i < skillViews.Count; i++)
        {
            skillViews[i].UpdateView(forgeSkills[i]);
        }
    }

    public void LevelUpSkill(int skillIndex)
    {
        switch (skillIndex)
        {
            case 0:
                TryUpgrade(forgeItemAmount,0);
                itemManager.LevelUpForge();
                break;
            case 1:
                TryUpgrade(forgingLevel,1);
                break;
            case 2:
                TryUpgrade(forgingSpeed,2);
                break;
            case 3:
                TryUpgrade(forgingAutomatization,3);
                hammerController.LevelUpAutomatization();
                break;
        }
    }

    private void TryUpgrade(ForgeSkill skill,int index)
    {
        if ( currencyManager.GetCurrencyValue()>skill.levelUpCost[skill.level])
        {
            currencyManager.RemoveCurrency(skill.levelUpCost[skill.level]);
            skill.level++;
            skillViews[index].UpdateView(skill);
        }
    }
}