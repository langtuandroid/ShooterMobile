using System;
using Gameplay.Characters.Players;
using Infrastructure.Projects;
using Infrastructure.SceneLoaders;
using Scenes._Infrastructure.Scripts;
using UnityEngine;
using Zenject;

namespace Gameplay.Portals
{
  public class Portal : MonoBehaviour
  {
    public PortalTypeId TypeId;
    public SceneId ToScene;

    [Tooltip("Время в секудах до активации после завершения арены")]
    public float ActivationDelay = 10f;

    [Tooltip("Время в секудах до активации при входа в триггер")]
    public float EnterDelay = 1f;

    [Inject] private SceneLoader _sceneLoader;
    [Inject] private ProjectData _projectData;

    private ParticleSystem _particleSystem;

    private bool _playerInTrigger;
    private bool _isActive;
    private float _timeLeftForActivation;
    private float _timeLeftForEnter;

    private void Awake()
    {
      _particleSystem = GetComponentInChildren<ParticleSystem>();
      Validate();

      Activate();
    }

    private void Update()
    {
      if (_isActive == false)
      {
        if (_timeLeftForActivation > 0)
          _timeLeftForActivation -= Time.deltaTime;
        else
          Activate();
      }

      if (_playerInTrigger)
      {
        if (_timeLeftForEnter > 0)
          _timeLeftForEnter -= Time.deltaTime;
        else
          LoadScene();
      }
      else
      {
        _timeLeftForEnter = EnterDelay;
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if (_isActive == false)
        return;

      if (_playerInTrigger)
        return;

      if (other.TryGetComponent(out PlayerTargetTrigger _))
      {
        _playerInTrigger = true;
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if (_isActive == false)
        return;

      if (!_playerInTrigger)
        return;

      if (other.TryGetComponent(out PlayerTargetTrigger _))
      {
        _playerInTrigger = false;
      }
    }

    private void Activate()
    {
      _isActive = true;
      _particleSystem.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
      _isActive = false;
      _particleSystem.gameObject.SetActive(false); 
      _timeLeftForActivation = ActivationDelay;
    }

    private void LoadScene()
    {
      switch (TypeId)
      {
        case PortalTypeId.Unknown:
          throw new ArgumentOutOfRangeException();

        case PortalTypeId.CoreToArena:
          _sceneLoader.Load(ToScene);
          break;

        case PortalTypeId.ArenaToCore:
          switch (_projectData.GameMode)
          {
            case GameMode.Unknown:
              throw new ArgumentOutOfRangeException();

            case GameMode.Default:
              _sceneLoader.Load(ToScene);
              break;

            case GameMode.VladTest:
              _sceneLoader.Load(SceneId.VladTestScene);
              break;

            case GameMode.SimeonTest:
              _sceneLoader.Load(SceneId.SimeonTestScene);
              break;

            case GameMode.ValeraTest:
              _sceneLoader.Load(SceneId.ValeraTestScene);
              break;

            default:
              throw new ArgumentOutOfRangeException();
          }

          break;

        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void Validate()
    {
      if (TypeId == PortalTypeId.Unknown || ToScene == SceneId.Unknown)
        throw new Exception("PortalTypeId or ToScene is unknown");
    }
  }
}