using Gameplay.Characters.Enemies.Animators;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories.GameobjectContext;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMeshModelSpawner
  {
    private EnemyMeshModelSpawner(AssetProvider assetProvider, EnemyTypeId enemyId,
      EnemyShootingPointProvider shootingPointProvider, IGameObjectZenjectFactory factory, EnemyAnimatorProvider animatorProvider,
      Transform transform, EnemyMeshMaterialChanger materialChanger)

    {
      EnemyMeshModel prefab = assetProvider.Get<EnemyMeshModel>(enemyId.ToString());

      EnemyMeshModel meshModel = factory.InstantiateMono(prefab, transform.position, transform);
      materialChanger.EnemyMeshModel = meshModel;

      shootingPointProvider.PointTransform = meshModel.GetComponent<EnemyShootingPoint>().PointTransform;

      animatorProvider.Instance = meshModel.GetComponent<EnemyAnimator>();
    }
  }
}