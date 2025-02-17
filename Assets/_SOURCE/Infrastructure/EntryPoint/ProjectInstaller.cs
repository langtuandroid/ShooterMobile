using Gameplay.Characters.Players;
using Gameplay.CurrencyRepositories;
using Gameplay.CurrencyRepositories.BackpackStorages;
using Gameplay.CurrencyRepositories.Expirience;
using Gameplay.Quests;
using Gameplay.RewardServices;
using Gameplay.Upgrades;
using Gameplay.Weapons;
using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Infrastructure.AudioServices;
using Infrastructure.ConfigServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.LoadingCurtains;
using Infrastructure.PersistentProgresses;
using Infrastructure.Projects;
using Infrastructure.RandomServices;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Infrastructure.VisualEffects;
using Infrastructure.VisualEffects.ParticleImages;
using Infrastructure.ZenjectFactories.ProjectContext;
using Inputs;
using Loggers;
using Zenject.Source.Install;

namespace Infrastructure.EntryPoint
{
  public class ProjectInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<ProjectInitializer>().FromInstance(GetComponent<ProjectInitializer>()).AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<ProjectZenjectFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadingCurtain>().FromComponentInNewPrefabResource(ProjectConstants.AssetsPath.Prefabs.LoadingCurtain).AsSingle();

      Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInNewPrefabResource(ProjectConstants.AssetsPath.Prefabs.CoroutineRunner).AsSingle();

      Container.BindInterfacesAndSelfTo<RandomService>().AsSingle();

      Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
      Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
      Container.BindInterfacesAndSelfTo<PersistentProgressService>().AsSingle();
      Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
      Container.BindInterfacesAndSelfTo<AudioService>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<DebugLogger>().AsSingle();

      Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<ConfigProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<ArtConfigProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<VisualEffectProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<ParticleImageProvider>().AsSingle();

      Container.BindInterfacesAndSelfTo<RewardService>().AsSingle();
      Container.BindInterfacesAndSelfTo<UpgradeService>().AsSingle();

      Container.BindInterfacesAndSelfTo<ProjectData>().AsSingle();
      Container.BindInterfacesAndSelfTo<EggsInBankStorage>().AsSingle();
      Container.BindInterfacesAndSelfTo<MoneyInBankStorage>().AsSingle();
      Container.BindInterfacesAndSelfTo<ExpierienceStorage>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<QuestStorage>().AsSingle();
      Container.BindInterfacesAndSelfTo<WeaponStorage>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<BackpackStorage>().AsSingle().NonLazy();

      Container.BindInterfacesAndSelfTo<WeaponShop>().AsSingle();

      Container.BindInterfacesAndSelfTo<PlayerStatsProvider>().AsSingle().NonLazy();
    }
  }
}