using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PingPongMechanicSmith : MonoBehaviour
{
    public Slider slider;
    bool IsClicked = false;
    float v = 0f;
    public void PingPongMechanic()
    {
        v = Mathf.PingPong(Time.time*1.0f , 2.0f) - 1f;
        slider.value = v;
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(100 - Mathf.Abs(v) * 100);
        }
        
    }
    public void Clicked()
    {
        IsClicked = true;
    }
    public void UnClicked()
    {
        IsClicked = false;
        Debug.Log(100 - Mathf.Abs(v) * 100);
        //Aqui Colocaria oque cada % de acerto faria 
        // Como por exemplo se ele acertasse no meio ele faria uma arma boa e etc.
    }
    void Update() 
    {    
        if(IsClicked)
        {
            PingPongMechanic(); 
        }
        
    }
}
