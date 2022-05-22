using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quests", menuName = "New Quests")]
public class QuestController : ScriptableObject
{

    public bool questIsActive = false;
    public bool questCompletd = false;
    public string titleQuest;
    public string descriptionQuest;
    public int goldReward;
    public QuestGoal goal;
}
