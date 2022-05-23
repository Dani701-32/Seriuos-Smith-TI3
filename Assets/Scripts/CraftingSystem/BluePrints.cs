using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrints : MonoBehaviour
{
    public Item[] itensBluePrint;

    public Item CheckMolde(int batidas)
    {
        switch (batidas)
        {
            
            default:
            return itensBluePrint[0]; 
            case 4:
            return itensBluePrint[1]; 
        }

    }
}
