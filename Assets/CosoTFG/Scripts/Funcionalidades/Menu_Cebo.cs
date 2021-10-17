using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Cebo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Indicator_place;
    public Button boton_accion;
    
    
    void Update() 
    {
        var cebo_colocado = FindObjectOfType<Cebo>();
        if(cebo_colocado != null)
        {
            Indicator_place.SetActive(false);
            boton_accion.interactable = false;
        }

        else{
            Indicator_place.SetActive(true);
            boton_accion.interactable = true;
        }

        
    }
}
