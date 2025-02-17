using TMPro;
using UnityEngine;

namespace Gameplay.Bombs
{
  public class BombDefuseText : MonoBehaviour
  {
    public TextMeshProUGUI Text;
    public BombDefuser BombDefuser;

    private void Update()
    {
      SetText();
    }

    public void SetText()
    {
      int value = (int)(BombDefuser.DefuseProgress * 100);

      Text.text = $"{value}%";
    }
  }
}