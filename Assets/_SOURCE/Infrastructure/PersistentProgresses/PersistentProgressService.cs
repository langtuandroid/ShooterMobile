using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Players;
using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using Gameplay.Upgrades;
using Infrastructure.ConfigServices;
using UnityEngine;

namespace Infrastructure.PersistentProgresses
{
  public class PersistentProgressService
  {
    private readonly ConfigProvider _configProvider;

    public PersistentProgressService(ConfigProvider configProvider)
    {
      _configProvider = configProvider;
    }

    public ProjectProgress ProjectProgress { get; private set; }

    public void LoadProgress(string getString) =>
      ProjectProgress =
        JsonUtility
          .FromJson<ProjectProgress>(getString);

    public void SetDefault()
    {
      DefaultProjectProgressConfig defConfig = _configProvider.DefaultProjectProgressConfig;
      PlayerConfig playerConfig = _configProvider.PlayerConfig;

      ProjectProgress = new ProjectProgress(defConfig.MoneyInBank, defConfig.EggsInBank, defConfig.Expierience, defConfig.MusicMute, playerConfig.StartWeapons[0],
        Upgrades(), Quests(), playerConfig.StartWeapons);
    }

    private List<UpgradeProgress> Upgrades() =>
      _configProvider
        .UpgradeConfigs
        .Select(upgrade => new UpgradeProgress(upgrade.Key, 0))
        .ToList();

    private List<QuestProgress> Quests()
    {
      var questProgresses = new List<QuestProgress>();

      Dictionary<QuestId, QuestConfig> questConfigs =
        _configProvider
          .QuestConfigs;

      foreach (KeyValuePair<QuestId, QuestConfig> questConfig in questConfigs)
      {
        List<SubQuestProgress> subQuests = new List<SubQuestProgress>();

        for (var i = 0; i < questConfig.Value.SubQuests.Count; i++)
        {
          SubQuestProgress subQuestProgress = new(questConfig.Value.SubQuests[i].Id, 0, QuestState.UnActivated);
          subQuests.Add(subQuestProgress);
        }

        questProgresses.Add(new QuestProgress(questConfig.Key, QuestState.UnActivated, subQuests));
      }

      return questProgresses;
    }
  }
}