using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Tarasca : Bestia
{
    void Start()
    {
        dialogo = this.GetComponentInChildren<Flowchart>();
    }
   
    void Update()
    {
        DistanciaRender();
        MirarJugador();
    }

    public void Dialogo()
    {   
        ComenzarDialogo();
        dialogo.ExecuteBlock("Dialogo_Tarasca");
    }

    public void Amenazado()
    {
        ComenzarDialogo();
        dialogo.ExecuteBlock("Derrota");
    }

    public void Eliminacion()
    {
        FindObjectOfType<Misiones_Controller>().Cambiar_Mision();
        Destroy(this.gameObject);
    }
}
