using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI cost;
    
    public void UpdateView(ForgeSkill skill)
    {
        title.text = $"{skill.name} lvl {skill.level}";
        description.text = skill.description;
        cost.text = skill.levelUpCost[skill.level].ToString();
    }
}
