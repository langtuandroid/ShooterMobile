using Gameplay.Characters.Players;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;

namespace Gameplay.Characters.Pets.Hens
{
  public class HenFactory
  {
    private readonly GameLoopZenjectFactory _factory;
    private readonly PlayerProvider _playerProvider;

    public HenFactory(GameLoopZenjectFactory factory, PlayerProvider playerProvider)
    {
      _factory = factory;
      _playerProvider = playerProvider;
    }

    public Hen Create()
    {
      Vector3 position = _playerProvider.Instance.PetSpawnPointsContainer.GetRandomSpawnPoint().position;

      var hen = _factory.InstantiateMono<Hen>(position);

      hen.transform.SetParent(null);

      return hen;
    }
  }
}