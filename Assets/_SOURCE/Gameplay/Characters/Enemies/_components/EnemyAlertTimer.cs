using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyAlertTimer
  {
    private float _timeLeft;
    
    private readonly EnemyConfig _config;

    public EnemyAlertTimer(EnemyConfig config)
    {
      _config = config;
    }

    public bool IsOver => _timeLeft <= 0;

    public void Reset()
    {
      _timeLeft = _config.AlertDuration;
    }

    public void Tick()
    {
      _timeLeft -= Time.deltaTime;
    }
  }
}