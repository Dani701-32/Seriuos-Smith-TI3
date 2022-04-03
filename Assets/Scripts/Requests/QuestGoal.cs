using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount; // quantidade de itens para se alcançar
    public int currentAmount; // quantidade atual

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount); // Se a quantidade atual for maior ou igual a quantidade necessaria return true
    }
}
public enum GoalType // tipo de pedidos q vao ser dados
{
    Weapons,Armatures,Ornaments
}
