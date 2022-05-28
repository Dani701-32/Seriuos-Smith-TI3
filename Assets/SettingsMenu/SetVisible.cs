using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVisible : MonoBehaviour
{
    public GameObject menuEsc;
    public GameObject livrinho;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // forma de ativar e desativar de maneira eficiente.
            // se esta ativado desativa / se esta desativado ativa.
            menuEsc.SetActive(!menuEsc.activeSelf);
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            // forma de ativar e desativar de maneira eficiente.
            // se esta ativado desativa / se esta desativado ativa.
            livrinho.SetActive(!livrinho.activeSelf);
        }
    }
}
