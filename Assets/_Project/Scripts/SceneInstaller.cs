using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private CurrencyManager currencyManager;
    public override void InstallBindings()
    {
        Container.BindInstance(currencyManager).AsSingle();
    }
}
