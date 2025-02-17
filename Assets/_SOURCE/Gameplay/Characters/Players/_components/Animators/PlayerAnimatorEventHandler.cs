using System;
using UnityEngine;

namespace Gameplay.Characters.Players.Animators
{
  public class PlayerAnimatorEventHandler : MonoBehaviour
  {
    public event Action Shot;

    public void Shoot()
    {
      Shot?.Invoke();
    }
  }
}