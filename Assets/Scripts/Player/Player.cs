using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour // Script pra guardar as quests
{
    public QuestController quest;
    public int energy = 100; // default energy
    public int maxEnergy = 100; // default max energy
    public int gold = 0;

    public bool HasQuest()
    {
        return (quest == null) ? false : true;
    }

    public void AdvanceQuest(Item item)
    {
        if (quest.goal.goalType == item.goalType && quest.goal.materialType == item.materialType)
        {
            quest.goal.currentAmount++;
            quest.questCompletd = quest.goal.IsReached();
        }
    }


}
