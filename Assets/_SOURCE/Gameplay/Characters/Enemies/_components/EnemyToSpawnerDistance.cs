using Gameplay.Spawners;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyToSpawnerDistance
  {
    private readonly EnemyConfig _config;
    private readonly EnemySpawner _spawner;
    private readonly Transform _transform;

    public EnemyToSpawnerDistance(EnemyConfig config, EnemySpawner spawner, Transform transform)
    {
      _config = config;
      _spawner = spawner;
      _transform = transform;
    }

    public float Value => (_spawner.transform.position - _transform.position).magnitude;
    public bool IsAway => Value > _config.PatrolingRadius;
  }
}