using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Quests
{
  [CreateAssetMenu(menuName = "ArtConfigs/QuestConfig", fileName = "QuestContentConfig")]
  public class QuestContentConfig : ScriptableObject
  {
    public List<QuestContentSetup> Setups; 
  }
}