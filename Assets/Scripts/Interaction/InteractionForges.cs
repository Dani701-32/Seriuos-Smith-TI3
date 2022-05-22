using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionForges : Interactable
{
    [SerializeField] private Forge forja;

    private void Awake()
    {
        forja = GameObject.FindGameObjectWithTag("GameController").GetComponent<Forge>();
    }
    public override void StayInteractor()
    {
        base.StayInteractor();
        forja.AbrirTela();
    }
}
