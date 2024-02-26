using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillDatabase", menuName = "ScriptableObjects/SkillDatabase")]

public class SkillDatabase : ScriptableObject
{
    [SerializeField] private List<ForgeSkill> forgeSkills;

    public List<ForgeSkill> GetForgeSkills()
    {
        return forgeSkills;
    }

    public ForgeSkill GetSpecifiedSkill(ForgeSkill.SkillType skillType)
    {

        ForgeSkill skill  =
            forgeSkills.FirstOrDefault(skill => skill.GetSkillType() == skillType);
        return skill;
    }
}
