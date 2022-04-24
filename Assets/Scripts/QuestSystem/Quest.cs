using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest //Scriptable Object para passar as informações da quest para o player
{
    public bool questIsActive;

    public string titleQuest;
    public string descriptionQuest;
    public int goldReward;

    public QuestGoal goal;

    public void QuestCompleted()
    {
        questIsActive = false;
        Debug.Log(titleQuest + " Was Completed");
    }
}
