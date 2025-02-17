using Gameplay.Characters.Enemies.StateMachines.States.Idle;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Bootstrap
{
  public class EnemyBootstrapToIdleTransition : Transition
  {
    public override void Tick()
    {
      Enter<EnemyIdleState>();
    }
  }
}