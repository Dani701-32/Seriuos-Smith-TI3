using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolderQuest : MonoBehaviour // Script pra guardar as quests
{
    public QuestController quest; // caso queira multiplas quest so mudar para uma Lista

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
