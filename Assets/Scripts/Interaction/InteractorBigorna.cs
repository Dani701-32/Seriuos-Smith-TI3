using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorBigorna : Interactable
{
    [SerializeField] private Bigorna bigorna;
    void Awake()
    {
        bigorna = GameObject.FindGameObjectWithTag("GameController").GetComponent<Bigorna>();
    }
    public override void StayInteractor()
    {
        base.StayInteractor();
        bigorna.AbrirTela();
    }
}
