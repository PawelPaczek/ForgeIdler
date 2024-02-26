using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemViewPoolInstaller : MonoInstaller
{
    public ItemView itemViewPrefab;
    public int poolSize = 10;

    public override void InstallBindings()
    {
        Container.Bind<ItemViewPool>()
            .FromMethod(CreateProjectilePool)
            .AsSingle();

        Container.BindInstance(itemViewPrefab).WhenInjectedInto<ItemViewPool>();
        Container.BindInstance(poolSize).WhenInjectedInto<ItemViewPool>();
    }

    private ItemViewPool CreateProjectilePool(InjectContext context)
    {
        ItemViewPool projectilePool = new ItemViewPool();
        projectilePool.InitializePool(itemViewPrefab,poolSize);
        return projectilePool;
    }
}
