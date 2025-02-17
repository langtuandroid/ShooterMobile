using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Pets.Hens
{
  public class HenVisualEffector : MonoBehaviour
  {
    [Inject] private VisualEffectFactory _visualEffectFactory;

    public void PlayExplosion()
    {
      _visualEffectFactory.Create(VisualEffectId.HenExplosion, transform.position, null);
    }
  }
}