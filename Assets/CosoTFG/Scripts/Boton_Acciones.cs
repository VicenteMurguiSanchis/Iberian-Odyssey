using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.Samples;

public class Boton_Acciones : MonoBehaviour
{
    public int accion;

    public Interactuador interactuador;
    public ObjectSpawner objectSpawner, llamar_anjana;
    public Image imagen_boton_accion;

    public Sprite imagen_interactuar, imagen_cebo, imagen_ayuda;

    void Awake()
    {
        accion = 0;
    }

    public void AccionBoton()
    {
        switch(accion)
        {
            case 1:
                interactuador.Interactuar();
                break;
            case 3:
                if(!GameObject.FindGameObjectWithTag("Cebo"))
                {
                    objectSpawner.DejarElemento();
                }
                break;
            case 6:
                llamar_anjana.DejarElemento();
                break;
        }
    }

    public void setAccionSprite(int a)
    {
        accion = a;
        switch(accion)
        {
            case 1:
                imagen_boton_accion.sprite = imagen_interactuar;
                break;
            case 3:
                imagen_boton_accion.sprite = imagen_cebo;
                break;
            case 6:
                imagen_boton_accion.sprite = imagen_ayuda;
                break;
        }
    }
}