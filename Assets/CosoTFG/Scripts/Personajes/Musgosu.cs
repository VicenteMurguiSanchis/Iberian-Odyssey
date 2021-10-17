using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Musgosu : Bestia
{

    private void Awake() {
        animator = this.GetComponent<Animator>();
        dialogo = this.GetComponentInChildren<Flowchart>();
        camara_pos = Camera.main.transform.position;
        dialogando = false;
    }

    void Update()
    {
        DistanciaRender();
        MirarJugador();
    }

    public void Dialogo()
    {
        if(PlayerPrefs.GetInt("num_mision",1) == 4)
        {
            dialogo.ExecuteBlock("Dialogo_Musgosu");
            
        }

        else{
            dialogo.ExecuteBlock("No_Preparado");
        }
        ComenzarDialogo();
    }

    public void SiguienteMision()
    {
        GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>().AddEntradaAccion(2);
        PlayerPrefs.SetInt("registro_PonerCebo",1);
        FindObjectOfType<Misiones_Controller>().Cambiar_Mision();
        Destroy(this.gameObject);
    }

    public void Gesticular()
    {
        animator.SetBool("gesto",true);
    }

    public void NoGesticular()
    {
        animator.SetBool("gesto",false);
    }
}
