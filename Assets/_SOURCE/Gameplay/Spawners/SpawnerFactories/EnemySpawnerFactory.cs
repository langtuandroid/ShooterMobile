﻿using System.Collections.Generic;
using System.Linq;
using Gameplay.Spawners.SpawnPoints;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories.SceneContext;
using Maps;
using Maps.Markers.EnemySpawnMarkers;
using UnityEngine;
using Zenject.Source.Main;

namespace Gameplay.Spawners.SpawnerFactories
{
  public class EnemySpawnerFactory
  {
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly EnemySpawner _spawnerPrefab;
    private readonly MapProvider _mapProvider;
    private readonly IInstantiator _instantiator;

    public EnemySpawnerFactory(AssetProvider assetProvider,
      GameLoopZenjectFactory zenjectFactory, MapProvider mapProvider, IInstantiator instantiator)
    {
      _zenjectFactory = zenjectFactory;
      _mapProvider = mapProvider;
      _instantiator = instantiator;
      
      _spawnerPrefab = assetProvider.Get<EnemySpawner>();
    }

    public List<EnemySpawner> Spawners { get; } = new();

    private Map Map => _mapProvider.Map;

    public void Create()
    {
      Transform container = Map.EnemySpawnersContainer;

      List<EnemySpawnMarker> spawnPointMarkers = Map.EnemySpawnMarkers;

      foreach (EnemySpawnMarker marker in spawnPointMarkers)
      {
        EnemySpawner enemySpawner = _instantiator.InstantiatePrefab(_spawnerPrefab, container).GetComponent<EnemySpawner>();

        enemySpawner.transform.SetParent(container);
        enemySpawner.transform.localPosition = marker.transform.localPosition;

        List<SpawnPoint> spawnPoints = CreateSpawnPoints(marker);
        enemySpawner.Init(marker.EnemyId, spawnPoints, marker.RespawnTime);

        if (enemySpawner == null)
          continue;

        enemySpawner.Spawn(marker.Count);

        Spawners.Add(enemySpawner);
      }
    }

    private List<SpawnPoint> CreateSpawnPoints(EnemySpawnMarker marker)
    {
      List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

      List<EnemySpawnPointMarker> markers = marker.GetComponentsInChildren<EnemySpawnPointMarker>().ToList();

      foreach (EnemySpawnPointMarker enemySpawnPointMarker in markers)
      {
        SpawnPoint spawnPoint = _zenjectFactory.InstantiateMono<SpawnPoint>();
        spawnPoint.transform.SetParent(enemySpawnPointMarker.transform);
        spawnPoint.transform.localPosition = Vector3.zero;
        spawnPoints.Add(spawnPoint);
      }

      return spawnPoints;
    }

    public void Destroy()
    {
      foreach (EnemySpawner spawner in Spawners)
      {
        spawner.DeSpawnAll();
      } 
      
      Spawners.Clear();
    }
  }
}