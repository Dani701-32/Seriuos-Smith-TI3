using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolderQuest : MonoBehaviour // Script pra guardar as quests
{
    public Quest quest; // caso queira multiplas quest so mudar para uma Lista
    public int gold = 0;

    public void MakeTheThing()
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
