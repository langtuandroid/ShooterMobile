using System.Collections.Generic;
using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows
{
  public class CurrentSubQuestText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private Quest _quest;

    private void Update()
    {
      List<SubQuest> subQuests = _quest.SubQuests;

      foreach (SubQuest subQuest in subQuests)
      {
        if (subQuest.State.Value is QuestState.Activated or QuestState.RewardReady)
        {
          SetText(subQuest.ContentSetup.Description + "(" + subQuest.Setup.Quantity + ")");
          return;
        }

        SetText("");
      }

      if (_quest.State.Value == QuestState.RewardTaken)
      {
        SetText("Completed");
      }
    }

    private void SetText(string text)
    {
      Text.text = text;
    }
  }
}