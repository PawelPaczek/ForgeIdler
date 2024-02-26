using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ForgingSkillsManager : MonoBehaviour
{
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private HammerController hammerController;
    [Inject] [SerializeField] private CurrencyManager currencyManager;
    [Inject] [SerializeField] private SkillDatabase skillDatabase;
    [SerializeField] private GameObject skillViewPrefab;
    [SerializeField] private Transform skillViewPrefabParent;
    [SerializeField] private List<SkillView> skillViews;

    private void Start()
    {
        for (int i = 0; i < skillDatabase.GetForgeSkills().Count; i++)
        {
            CreatSkillButton(i);
        }
    }

    private void CreatSkillButton(int i)
    {
        GameObject viewPrefab = Instantiate(skillViewPrefab, skillViewPrefabParent);
        SkillView skillPrefabView = viewPrefab.GetComponent<SkillView>();
        skillPrefabView.UpdateView(skillDatabase.GetForgeSkills()[i]);
        skillViews.Add(skillPrefabView);
        skillPrefabView.OnLevelUpClick += LevelUpSkill;
    }
    
    public void LevelUpSkill(ForgeSkill skill, SkillView skillView)
    {
        TryUpgrade(skill, skillView);
        itemManager.LevelUpForge();
        hammerController.LevelUpAutomatization();
    }

    private void TryUpgrade(ForgeSkill skill, SkillView skillView)
    {
        if (currencyManager.GetCurrencyValue() > skill.GetLevelCost()[skill.GetLevel()])
        {
            currencyManager.RemoveCurrency(skill.GetLevelCost()[skill.GetLevel()]);
            skill.AddLevel();
            skillView.UpdateView(skill);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < skillViews.Count; i++)
        {
            skillViews[i].OnLevelUpClick -= LevelUpSkill;
        }
    }
}