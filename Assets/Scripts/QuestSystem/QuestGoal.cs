using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal // Objetivo da quest
{
    public QuestGoalType goalType;
    public MaterialType materialType;

    public int requiredAmount; //amontuado necessario 
    public int currentAmount; // amontuado atual 

    public bool IsReached() // se a quest foi completada.
    {
        return (currentAmount >= requiredAmount);
    }

    ///////////////////EXEMPLES/////////////////////////////

    // public void WeaponCraft()
    // {
    //     if (goalType == QuestGoalType.WeaponCraft)
    //     {
    //         currentAmount++;
    //     }
    // }
    // public void ShieldCraft()
    // {
    //     if (goalType == QuestGoalType.ArmorCraft)
    //     {
    //         currentAmount++;
    //     }
    // }

    // public void RawMaterial()
    // {

    // }

    /*public void ArmorCraft()
    {
        if (goalType == QuestGoalType.shieldCraft)
        {
            currentAmount++;
        }
    }
    */
}
public enum QuestGoalType
{
    WeaponCraft, ArmorCraft, ShieldCraft, RawMaterial
}

public enum MaterialType
{
    Wood, Copper, Iron, Steel
}
public enum States
{
    Ambiente , Quente , Frio , Queimado , Quebrado
}

