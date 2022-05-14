using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalcaoInterect : Interactable
{
    public GameObject questSystemUI;
    public QuestGiver giverQuest;
    bool hasActive = false;
    public override void Interact()
    {
        base.Interact();
        giverQuest.OpenQuestWindow();
    }
}
