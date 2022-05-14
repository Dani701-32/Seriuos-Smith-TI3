using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour // Aqui vai ser onde vai ter as quest/recepies que vao vir os pedidos e vao ser
                                        //passados para o player
{
    public List<QuestController> tempController = new List<QuestController>();
    public Queue<QuestController> controllerQuest = new Queue<QuestController>();
    private QuestController quest;
    public GameObject questUI;
    public Text titleQuest;
    public Text descriptionQuest;
    public Text goldReward;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerHolderQuest playerHolder;
    private void Awake()
    {
        questUI.SetActive(false);
        foreach (QuestController item in tempController)
        {
            controllerQuest.Enqueue(item);
        }
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerHolder = p.GetComponent<PlayerHolderQuest>();
        playerMovement = p.GetComponent<PlayerMovement>();
    }
    public void OpenQuestWindow()
    {
        playerMovement.enabled = false;
        questUI.SetActive(true);
        UpdateQuest();
    }
    private void UpdateQuest()
    {
        if (controllerQuest.Count > 0)
        {
            quest = (quest) ? quest : controllerQuest.Dequeue();
            titleQuest.text = quest.titleQuest;
            descriptionQuest.text = $"Quest description: {quest.descriptionQuest}";
            goldReward.text = $"Reward: {quest.goldReward}";
        }
        else
        {
            titleQuest.text = "Nothing to see here.";
            descriptionQuest.text = "No available quest for now";
            goldReward.text = "";
        }
    }

    public void AcceptQuest()
    {
        if (!quest || playerHolder.quest)
        {
            return;
        }
        questUI?.SetActive(false);
        quest.questIsActive = true;
        playerMovement.enabled = true;
        playerHolder.quest = quest;
        quest = null;
    }

    public void CloseQuestWindow()
    {
        playerMovement.enabled = true;
        questUI.SetActive(false);
    }
    public void DeclineQuest()
    {
        quest = null;
        UpdateQuest();
    }
}