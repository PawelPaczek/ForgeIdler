using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Zenject;

public class HammerController : MonoBehaviour
{
    [SerializeField] private Transform hammer;
    [SerializeField] private Image particle;
    [SerializeField] private Animator coinsAnimator;
    [Inject][SerializeField] private SkillDatabase skillDatabase;
    [SerializeField] private DropManager dropManager;
    private ForgeSkill automatizationSkill;
    
    private void Start()
    {
        ForgeSkill forgingAutomatizationSkill =
            skillDatabase.GetSpecifiedSkill(ForgeSkill.SkillType.ForgingAutomatization);
        if (forgingAutomatizationSkill == null) return;

        if (forgingAutomatizationSkill.GetLevel() > 0)
        {
            StartCoroutine(ShowParticleLoop(forgingAutomatizationSkill));
        }
    }

    public void LevelUpAutomatization()
    {
        ForgeSkill forgingAutomatizationSkill =
            skillDatabase.GetSpecifiedSkill(ForgeSkill.SkillType.ForgingAutomatization);
        if (forgingAutomatizationSkill == null) return;

        if (forgingAutomatizationSkill.GetLevel() > 0)
        {
            StartCoroutine(ShowParticleLoop(forgingAutomatizationSkill));
        }
    }

    private IEnumerator ShowParticleLoop(ForgeSkill forgingAutomatizationSkill)
    {
        automatizationSkill = forgingAutomatizationSkill;
        while (forgingAutomatizationSkill.GetLevel() > 0)
        {
            RotateHammer();
            yield return new WaitForSeconds(2f);
        }
    }

    public void RotateHammer()
    {
        dropManager.SpawnItems();
        hammer.DOLocalRotate(new Vector3(0, 0, 60), 0.25f).OnComplete(ShowParticle);
    }

    private void ShowParticle()
    {
        coinsAnimator.Play("CoinsAnimation");
        particle.DOFade(1, 0.2f).SetEase(Ease.Linear).OnComplete(() => particle.DOFade(0, 0.2f).SetEase(Ease.Linear));
        hammer.DOLocalRotate(new Vector3(0, 0, 0), 0.25f);
    }

    private void OnDisable()
    {
        if (ShowParticleLoop(automatizationSkill) != null)
        {
            StopCoroutine(ShowParticleLoop(automatizationSkill));
        }
    }
}