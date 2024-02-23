using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HammerController : MonoBehaviour
{
    [SerializeField] private Transform hammer;
    [SerializeField] private Image particle;
    [SerializeField] private Animator coinsAnimator;
    [SerializeField] private ForgingSkillsManager forgingSkillsManager;
    [SerializeField] private DropManager dropManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateHammer();
        }
    }

    private void Start()
    {
        if (forgingSkillsManager.forgingAutomatization.level  > 0)
        {
            StartCoroutine(ShowParticleLoop());
        }
    }

    public void LevelUpAutomatization()
    {
        if (forgingSkillsManager.forgingAutomatization.level > 0)
        {
            StartCoroutine(ShowParticleLoop());
        }
    }
    
    private IEnumerator ShowParticleLoop()
    {
        while (forgingSkillsManager.forgingAutomatization.level  > 0)
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
        if (ShowParticleLoop() != null)
        {
            StopCoroutine(ShowParticleLoop());
        }
    }
}
