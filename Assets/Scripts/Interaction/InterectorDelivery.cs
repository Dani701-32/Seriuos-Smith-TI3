using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterectorDelivery : Interactable
{
    [SerializeField] private QuestDelivery delivery;

    private void Awake()
    {
        delivery = GameObject.FindGameObjectWithTag("GameController").GetComponent<QuestDelivery>();
    }
    public override void StayInteractor()
    {
        base.StayInteractor();
        delivery.OpenDelivery();

    }
}
