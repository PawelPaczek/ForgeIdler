using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MyScriptableObjectInstaller", menuName = "Installers/MyScriptableObjectInstaller")]
public class MyScriptableObjectInstaller :  ScriptableObjectInstaller<MyScriptableObjectInstaller>
{
    [SerializeField] private SkillDatabase skillDatabase;

    public override void InstallBindings()
    {
        Container.BindInstance(skillDatabase).AsSingle();
    }
}
