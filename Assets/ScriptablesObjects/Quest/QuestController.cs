using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quests" , menuName = "New Quests")]
public class QuestController : ScriptableObject
{
    
    public bool questIsActive;

    public string titleQuest;
    public string descriptionQuest;
    public int goldReward;

    public QuestGoal goal;
    //public Quest quest; // caso precisar de mais pedidos substituir isso por um Array

    public void QuestCompleted() // chamar essa fun��o quando o pedido estiver pronto
    {
        questIsActive = false;
        Debug.Log(titleQuest + " Was Completed");
    }
}
