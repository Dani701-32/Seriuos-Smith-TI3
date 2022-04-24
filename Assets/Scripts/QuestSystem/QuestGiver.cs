using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour // Aqui vai ser onde vai ter as quest/recepies que vao vir os pedidos e vao ser
    //passados para o player
{
    public Quest quest;
    public PlayerHolderQuest player;
    public GameObject windowQuest;

    public Text titleQuest;
    public Text descriptionQuest;
    public int goldReward;
    public void OpenQuestWindow()
    {
        windowQuest.SetActive(true);
        titleQuest.text = quest.titleQuest;
        descriptionQuest.text = quest.descriptionQuest;
    }

    public void AcceptQuest()
    {
        windowQuest?.SetActive(false);
        quest.questIsActive = true;
        player.quest = quest;
    }
}
