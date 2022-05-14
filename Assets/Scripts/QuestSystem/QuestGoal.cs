using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal // Objetivo da quest
{
    public QuestGoalType goalType;

    public int requiredAmount; //amontuado necessario 
    public int currentAmount; // amontuado atual 

    public bool IsReached() // se a quest foi completada.
    {
        return (currentAmount >= requiredAmount);
    }
    /// <summary>
    /// ///////////////////EXEMPLES/////////////////////////////
    /// </summary>
    public void WeaponCraft()
    {
        if(goalType == QuestGoalType.weaponCraft)
        {
            currentAmount++;
        }
    }
    public void OrnamentCraft()
    {
        if (goalType == QuestGoalType.ornamentCraft)
        {
            currentAmount++;
        }
    }

    public void ArmorCraft()
    {
        if (goalType == QuestGoalType.armorCraft)
        {
            currentAmount++;
        }
    }
}
public enum QuestGoalType
{ 
    weaponCraft , ornamentCraft , armorCraft
}

