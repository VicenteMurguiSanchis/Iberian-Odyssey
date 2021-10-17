using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ayuda : MonoBehaviour
{
    public Button boton_menu;
    public GameObject Indicator_place;
    public GameObject boton_accion;
      
    void Update() 
    {
        var anjana = FindObjectOfType<Anjana>();
        if(anjana != null)
        {
            boton_menu.interactable = false;
            Indicator_place.SetActive(false);
            boton_accion.SetActive(false);
        }

        else{
            boton_menu.interactable = true;
            Indicator_place.SetActive(true);
            boton_accion.SetActive(true);
        }  
    }
}
