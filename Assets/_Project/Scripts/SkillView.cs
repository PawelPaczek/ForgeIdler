using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private Button button;
    private ForgeSkill assignedForgeSkill;
    public Action<ForgeSkill,SkillView> OnLevelUpClick;
    
    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OnLevelUpClick?.Invoke(assignedForgeSkill,this);
    }

    public void UpdateView(ForgeSkill skill)
    {
        assignedForgeSkill = skill;
        title.text = $"{skill.name} lvl {skill.GetLevel()}";
        description.text = skill.GetDescription();
        cost.text = skill.GetLevelCost()[skill.GetLevel()].ToString();
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }
}
