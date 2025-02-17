using Infrastructure.SceneLoaders;
using Scenes._Infrastructure.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.DebugWindows
{
  public class ChangeGameModeButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private SceneLoader _sceneLoader;

    private void Start()
    {
      Button.onClick.AddListener(ChangeGameMode);
    }

    private void ChangeGameMode()
    {
      _sceneLoader.Load(SceneId.ChooseGameMode);
    }
  }
}