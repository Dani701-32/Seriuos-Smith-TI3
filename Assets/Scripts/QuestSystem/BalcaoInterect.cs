using UnityEngine;

public class BalcaoInterect : Interactable
{
    public GameObject questSystemUI;
    public QuestGiver giverQuest;
    // bool hasActive = false;
    public override void StayInteractor()
    {
        base.StayInteractor(); 
        giverQuest.OpenQuestWindow();
    }
}
