using Gameplay.Quests;
using Infrastructure.UserIntefaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Buttons.OpenQuestButtons
{
  public class OpenQuestButton : MonoBehaviour
  {
    public Button Button;
    public RectTransform RectTransform;
    
    public QuestId QuestId { get; set; } = QuestId.Unknown;

    [Inject] private WindowService _windowService;

    private void Awake()
    {
      Button.onClick.AddListener(OpenQuest);
    }

    private void OpenQuest()
    {
      if (QuestId == QuestId.Unknown)
        throw new System.Exception("Unknown quest id");

      _windowService.Create(WindowId.Quest, QuestId);
    }
  }
}