using Gameplay.CurrencyRepositories.Expirience;
using Infrastructure.ConfigServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Bars.ExpirienceBars
{
  public class ExpirienceText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    private ExpierienceStorage _expierienceStorage;
    private ConfigProvider _configProvider;

    [Inject]
    public void Construct(ExpierienceStorage expierienceStorage, ConfigProvider configProvider)
    {
      _expierienceStorage = expierienceStorage;
      _configProvider = configProvider;
    }

    private ExpirienceConfig Config => _configProvider.ExpirienceConfig;

    private void OnEnable()
    {
      SetText(_expierienceStorage.CurrentExpierience());
      _expierienceStorage.AllPoints.ValueChanged += SetText;
    }

    private void OnDisable()
    {
      _expierienceStorage.AllPoints.ValueChanged -= SetText;
    }

    private void SetText(int value)
    {
      int currentExpierience = _expierienceStorage.CurrentExpierience();
      int expierienceToNextLevel = _expierienceStorage.ExpierienceToNextLevel();

      Text.text = $"{currentExpierience}/{expierienceToNextLevel} exp";
    
      SetColor();
    }

    private void SetColor()
    {
      int currentLevel = _expierienceStorage.CurrentLevel();
      Color newColor = Config.Levels[currentLevel - 1].Color;
      newColor.a = 255;

      if (Text.color != newColor)
        Text.color = newColor;
    }
  }
}