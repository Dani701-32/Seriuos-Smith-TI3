using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafts : MonoBehaviour
{
    public enum TypeOfCrafts
    {
        FORJA,
        BIGORNA,
        AFIADOR,
        ESFRIAR
    }
    public TypeOfCrafts typesOfCrafts;

    public void teste()
    {
        typesOfCrafts = TypeOfCrafts.FORJA;
    }

}
