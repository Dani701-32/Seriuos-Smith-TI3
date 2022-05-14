using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour // Aqui vai ser onde vai ter as quest/recepies que vao vir os pedidos e vao ser
    //passados para o player
{
    
    public List<QuestController> controllerQuest = new List<QuestController>();
    //public List<Quest> quest;
    public PlayerHolderQuest player;

    public GameObject windowQuest;

    public Text titleQuest;
    public Text descriptionQuest;
    public Text goldReward;
    

    public void OpenQuestWindow()
    {
        windowQuest.SetActive(true);

        titleQuest.text = controllerQuest[0].titleQuest;
        descriptionQuest.text = controllerQuest[0].descriptionQuest;
        goldReward.text = controllerQuest[0].goldReward.ToString();
    }

    public void AcceptQuest()
    {
        windowQuest?.SetActive(false);
        controllerQuest[0].questIsActive = true;
        player.quest = controllerQuest[0];
    }

    public void CheckIfOver()
    {
        player.CheckQuest();
        controllerQuest.Remove(controllerQuest[0]);
    }
    
}