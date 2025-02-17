using System;
using UnityEngine;

namespace Gameplay.Quests.Subquests
{
  [Serializable]
  public class SubQuestContentSetup
  {
    public SubQuestId Id;
    public Sprite Icon;
    public string Name;
    public string Description;
  }
}