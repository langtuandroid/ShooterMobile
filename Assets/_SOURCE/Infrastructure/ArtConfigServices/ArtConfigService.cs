using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Enemies;
using Gameplay.CurrencyRepositories;
using Gameplay.Loots;
using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using Gameplay.Rewards;
using Gameplay.Stats;
using Gameplay.Upgrades;
using Gameplay.Weapons;
using Infrastructure.AssetProviders;

namespace Infrastructure.ArtConfigServices
{
  public class ArtConfigProvider
  {
    private readonly AssetProvider _assetProvider;

    public ArtConfigProvider(AssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    private Dictionary<CurrencyId, LootContentSetup> _loots;
    private Dictionary<StatId, UpgradeContentSetup> _upgrades;
    private Dictionary<QuestId, QuestContentSetup> _quests;
    private Dictionary<SubQuestId, SubQuestContentSetup> _subQuests;
    private Dictionary<WeaponTypeId, WeaponContentSetup> _weapons;
    private Dictionary<RewardId, RewardContentSetup> _rewards;

    public EnemyCommonVisualsConfig EnemyCommonVisualsConfig { get; private set; }

    public LootContentSetup GetLootContentSetup(CurrencyId id) => _loots[id];
    public UpgradeContentSetup GetUpgradeContentSetup(StatId id) => _upgrades[id];
    public QuestContentSetup GetQuestContentSetup(QuestId questId) => _quests[questId];
    public SubQuestContentSetup GetSubQuestContentSetup(SubQuestId id) => _subQuests[id];
    public WeaponContentSetup GetWeaponContentSetup(WeaponTypeId id) => _weapons[id];
    public RewardContentSetup GetRewardContentSetup(RewardId id) => _rewards[id];

    public void LoadConfigs()
    {
      EnemyCommonVisualsConfig = _assetProvider.GetScriptable<EnemyCommonVisualsConfig>();

      _loots = _assetProvider.GetScriptable<LootIconsConfig>().Setups.ToDictionary(x => x.Id, x => x);
      _upgrades = _assetProvider.GetScriptable<UpgradeContentConfig>().Setups.ToDictionary(x => x.Id, x => x);
      _quests = _assetProvider.GetScriptable<QuestContentConfig>().Setups.ToDictionary(x => x.Id, x => x);
      _subQuests = _assetProvider.GetScriptable<SubQuestContentConfig>().Setups.ToDictionary(x => x.Id, x => x);
      _weapons = _assetProvider.GetScriptable<WeaponContentConfig>().Setups.ToDictionary(x => x.Id, x => x);
      _rewards = _assetProvider.GetScriptable<RewardContentConfig>().Setups.ToDictionary(x => x.Id, x => x);
    }
  }
}