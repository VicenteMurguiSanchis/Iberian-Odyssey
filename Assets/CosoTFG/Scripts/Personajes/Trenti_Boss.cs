using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Trenti_Boss : Bestia
{
    void Start()
    {
        animator = GetComponent<Animator>();
        dialogo = GetComponentInChildren<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanciaRender();
        MirarJugador();
    }

    public void Dialogo()
    {
        ComenzarDialogo();

        int mision = FindObjectOfType<Misiones_Controller>().misionActual;

        switch(mision)
        {
            case 1:
                animator.SetBool("cry",true);
                dialogo.ExecuteBlock("Mision1");
                FindObjectOfType<Misiones_Controller>().Cambiar_Mision();
            break;
            case 2:
                animator.SetBool("cry",true);
                dialogo.ExecuteBlock("Mision2");
            break;
            case 3:
                animator.SetBool("cry",false);
                animator.SetBool("happy",true);
                dialogo.ExecuteBlock("Mision3");
                FindObjectOfType<Misiones_Controller>().Cambiar_Mision();
            break;
        }
    }

    public void Irse()
    {
        TerminarDialogo();
        Destroy(this.gameObject);
    }

    public void CerrarDialogoCry()
    {
        TerminarDialogo();
        animator.SetBool("cry",false);
    }
}
