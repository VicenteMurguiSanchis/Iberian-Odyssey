using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Misiones_Controller : MonoBehaviour
{

    public int misionActual;
    private int misionAnterior;
    public GameObject trenti;
    public GameObject spawn_trenti1, spawn_trenti2;
    public GameObject Musgosu;
    public GameObject cofre_cuelebre;
    public GameObject Tarasca;
    public GameObject OrdenFinal;
    public Brujula brujula;
    public Button botonAyuda;
    public Menu_Juego ayuda;


    private void Awake() {
        misionActual = PlayerPrefs.GetInt("num_mision",1);
        ActivarMision(misionActual);
        switch(misionActual)
        {
            case 3:
                Destroy(spawn_trenti1);
                Destroy(spawn_trenti2);
                break;
            case 4:
                Destroy(spawn_trenti1);
                Destroy(spawn_trenti2);
                Destroy(trenti);
                break;
            case 5:
                Destroy(spawn_trenti1);
                Destroy(spawn_trenti2);
                Destroy(trenti);
                Destroy(Musgosu);
                break;
            case 6:
                Destroy(spawn_trenti1);
                Destroy(spawn_trenti2);
                Destroy(trenti);
                Destroy(Musgosu);
                cofre_cuelebre.GetComponent<Cofre_Cuelebre>().abierto = true;
                break;
            case 7:
                Destroy(spawn_trenti1);
                Destroy(spawn_trenti2);
                Destroy(trenti);
                Destroy(Musgosu);
                cofre_cuelebre.GetComponent<Cofre_Cuelebre>().abierto = true;
                Destroy(Tarasca);
                break;
        }
    }

    public void Cambiar_Mision()
    {
        misionActual++;
        if(misionActual != misionAnterior)
        {
            misionAnterior = misionActual;
            PlayerPrefs.SetInt("num_mision",misionActual);
            brujula.deleteObjetivos();
            ActivarMision(misionActual);
            ayuda.MostrarNuevaAyuda();
        }
    }

    public void ActivarMision(int id_mision)
    {
        switch(id_mision)
        {
            case 1:
                brujula.addObjetivo(trenti);
                break;
            case 2:
                brujula.addObjetivo(spawn_trenti1);
                brujula.addObjetivo(spawn_trenti2);
                break;
            case 3:
                brujula.addObjetivo(trenti);
                break;
            case 4:
                Musgosu.SetActive(true);
                brujula.addObjetivo(Musgosu);
                break;
            case 5:
                brujula.addObjetivo(cofre_cuelebre);
                break;
            case 6:
                brujula.addObjetivo(Tarasca);
                break;
            case 7:
                botonAyuda.interactable = true;
                OrdenFinal.SetActive(true);
                break; 
        }
    }
}