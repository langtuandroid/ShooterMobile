using System.Collections.Generic;
using Gameplay.CurrencyRepositories;
using Gameplay.CurrencyRepositories.BackpackStorages;
using Gameplay.Loots;
using Infrastructure.AssetProviders;
using UnityEngine;
using UserInterface.HeadsUpDisplays.LootSlotsUpdaters.LootSlots;
using Zenject;

namespace UserInterface.HeadsUpDisplays.LootSlotsUpdaters
{
  public class LootSlotsUpdater : MonoBehaviour
  {
    public List<LootSlot> LootSlots = new();

    [Inject] private LootSlotFactory _lootSlotFactory;
    [Inject] private BackpackStorage _backpackStorage;
    [Inject] private AssetProvider _assetProvider;

    private LootSlot Prefab => _assetProvider.Get<LootSlot>();

    private void OnEnable()
    {
      _backpackStorage.LootDrops.Changed += OnLootDropsChanged;
    }

    private void OnDisable()
    {
      _backpackStorage.LootDrops.Changed -= OnLootDropsChanged;
    }

    private void OnLootDropsChanged(List<LootDrop> list)
    {
      foreach (LootSlot loot in LootSlots)
        Destroy(loot.gameObject);

      LootSlots.Clear();

      Dictionary<CurrencyId, int> info = _backpackStorage.ReadLoot();

      foreach (KeyValuePair<CurrencyId, int> loot in info)
        _lootSlotFactory.Create(loot.Key, Prefab, transform, loot.Value);
    }
  }
}