using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public GameObject requestCanvasUI;
    public Controller controller;
    public Text requestType;
    public Text requestDescription;
    public Text goldReward;

    public void OpenQuestWindow()
    {
        requestType.text = quest.requestType;
        requestDescription.text = quest.requestDiscription;
        goldReward.text = quest.goldReward.ToString();
    }
    public void AcceptQuest()
    {
        requestCanvasUI.SetActive(false);
        quest.questIsActive = true;
        controller.quest = quest;
    }
}
