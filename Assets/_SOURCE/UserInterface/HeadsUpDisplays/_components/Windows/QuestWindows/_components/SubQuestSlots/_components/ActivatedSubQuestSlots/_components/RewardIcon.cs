using Gameplay.Quests.Subquests;
using Gameplay.Rewards;
using Infrastructure.ArtConfigServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows.SubQuestSlots.ActivatedSubQuestSlots
{
  public class RewardIcon : MonoBehaviour
  {
    public Image Image;

    [Inject] private SubQuest _subQuest;
    [Inject] private ArtConfigProvider _artConfigProvider;

    private void OnEnable()
    {
      RewardContentSetup contentSetup = _artConfigProvider.GetRewardContentSetup(_subQuest.Setup.Reward.RewardId);

      Image.sprite = contentSetup.Icon;
    }
  }
}