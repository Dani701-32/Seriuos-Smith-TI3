using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInterectable : MonoBehaviour, IInterectable
{
    [SerializeField] private string test = "test";

    //Define qual tipo de intereção o player tera com o objeto
    public void Interect()
    {
        Debug.Log(test);
    }

}
