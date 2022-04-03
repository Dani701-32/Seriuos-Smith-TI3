using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool questIsActive;

    public string requestType;
    public string requestDiscription;
    public int goldReward;

    public QuestGoal goal;
}
