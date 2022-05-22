using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDelivery : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private QuestController currentQuest;
    [SerializeField] private PlayerHolderQuest playerHolder;
    [SerializeField] private PlayerMovement playerMovement;
    private bool questCompleted;
    public GameObject questUI;
    public Text titleQuest;
    public Text titleStatus;
    public Text descriptionQuest;
    public Text goldReward;

    public Button deliveryButton;
    // [SerializeField] private 
    private void Awake()
    {
        questUI.SetActive(false);
        _inventory = gameObject.GetComponent<Inventory>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerHolder = p.GetComponent<PlayerHolderQuest>();
        playerMovement = p.GetComponent<PlayerMovement>();
        titleQuest.text = "Current quest empty";
        titleStatus.text = "";
        descriptionQuest.text = "";
        goldReward.text = "";
        deliveryButton.interactable = false;
    }
    //Verificar se o item da Quest Atual está no inventário. 
    public void SetQuest(QuestController quest) { currentQuest = quest; }
    public void RemoveQuest()
    {
        currentQuest = null;
        titleQuest.text = "Current quest empty";
        titleStatus.text = "";
        descriptionQuest.text = "";
        goldReward.text = "";
        deliveryButton.interactable = false;
    }
    public void OpenDelivery()
    {
        questUI.SetActive(true);
        playerMovement.enabled = false;
        if (currentQuest != null)
        {
            titleQuest.text = currentQuest.titleQuest;
            questCompleted = currentQuest.goal.IsReached();
            deliveryButton.interactable = questCompleted;
            titleStatus.text = (questCompleted) ? "COMPLETED" : "INCOMPLETED";
            descriptionQuest.text = $"{currentQuest.descriptionQuest} \n {currentQuest.goal.currentAmount}/ {currentQuest.goal.requiredAmount}";
            goldReward.text = currentQuest.goldReward.ToString();
        }
    }

    //Remover o item do inventário 
    //Passar para o Cliente

    public void Complete()
    {
        playerHolder.gold += currentQuest.goldReward;
        _inventory.Remove(currentQuest.goal.materialType, currentQuest.goal.requiredAmount);
        playerMovement.enabled = true;
        RemoveQuest();
        playerHolder.quest = null;
        questUI.SetActive(false);
    }

    public void CloseQuestWindow()
    {
        playerMovement.enabled = true;
        questUI.SetActive(false);
    }

}
