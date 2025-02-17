using UnityEngine;

namespace Gameplay.Characters.Questers.Animators
{
  public class QuesterAnimator : MonoBehaviour
  {
    [SerializeField] private Animator _animator;

    private static readonly int s_talk = Animator.StringToHash(IsTalk);

    private const string IsTalk = nameof(IsTalk);

    public void PlayTalkAnimation()
    {
      _animator.SetBool(s_talk, true);
    }

    public void StopTalkAnimation()
    {
      _animator.SetBool(s_talk, false);
    }
  }
}