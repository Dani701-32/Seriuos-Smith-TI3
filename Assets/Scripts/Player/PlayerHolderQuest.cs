using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolderQuest : MonoBehaviour // Script pra guardar as quests
{
    public QuestController quest; // caso queira multiplas quest so mudar para uma Lista
    public int gold = 0;

    public void CheckQuest()
    {
        if (quest.questIsActive)
        {
            quest.goal.WeaponCraft();
            if (quest.goal.IsReached())
            {
                gold += quest.goldReward;
                quest.QuestCompleted();
            }
        }
    }
}
