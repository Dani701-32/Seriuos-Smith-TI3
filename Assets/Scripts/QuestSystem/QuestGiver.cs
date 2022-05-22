using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour // Aqui vai ser onde vai ter as quest/recepies que vao vir os pedidos e vao ser passados para o player
{
    public List<QuestController> tempController = new List<QuestController>();
    public Queue<QuestController> controllerQuest = new Queue<QuestController>();
    private QuestController quest;
    public GameObject questUI;
    public Text titleQuest;
    public Text descriptionQuest;
    public Text goldReward;
    public Text buttonDeclinedQuest;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerHolderQuest playerHolder;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private QuestDelivery delivery;
    private void Awake()
    {
        questUI.SetActive(false);
        delivery = gameObject.GetComponent<QuestDelivery>();
        _inventory = gameObject.GetComponent<Inventory>();
        foreach (QuestController item in tempController)
        {
            item.questCompletd = false;
            item.questIsActive = false;
            item.goal.currentAmount = 0;
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
            if (playerHolder.quest == null)
            {
                quest = (quest) ? quest : controllerQuest.Dequeue();
                titleQuest.text = quest.titleQuest;
                buttonDeclinedQuest.text = "Decline";
            }
            else
            {
                quest = playerHolder.quest;
                titleQuest.text = quest.titleQuest + "\n Current quest";
                buttonDeclinedQuest.text = "Abandon";
            }
            descriptionQuest.text = $"Quest description: {quest.descriptionQuest} \n Required amount: {quest.goal.requiredAmount}";
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
        delivery.SetQuest(quest);
        quest = null;
        _inventory.CheckQuest();
    }

    public void CloseQuestWindow()
    {
        playerMovement.enabled = true;
        questUI.SetActive(false);
    }
    public void DeclineQuest()
    {
        if (playerHolder.quest != null)
        {
            playerHolder.quest = null;
            delivery.RemoveQuest();
        }
        quest = null;
        UpdateQuest();
    }
}