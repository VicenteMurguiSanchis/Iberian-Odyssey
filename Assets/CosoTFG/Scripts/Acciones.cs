using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acciones : MonoBehaviour
{   
    public GameObject Menu_Acciones;
    public GameObject Menu_Desplegable;

    public GameObject Menu_Analizar;

    public GameObject Menu_Interactuar;

    public GameObject Menu_Ayuda;
    public GameObject Boton_accion;
    public GameObject Menu_Cebo;

    public GameObject Menu_Cruz;

    public Boton_Acciones accion_botones;

    public GameObject PlanoCruz;

    public Brujula brujula;

    private GameObject[] flechas_brujula;

    //Activa el menú de la acción Poner Cebo
    public void Onclick_PonerCebo()
    {
        PlanoCruz.SetActive(false);
        flechas_brujula = GameObject.FindGameObjectsWithTag("Flecha_Brujula");
        foreach(GameObject flecha in flechas_brujula)
        {
            flecha.GetComponent<Direccion_flecha>().activada = false;
        }
        Destroy(GameObject.FindGameObjectWithTag("Cruz"));
        Menu_Interactuar.SetActive(false);
        Menu_Ayuda.SetActive(false);
        Boton_accion.SetActive(true);
        Boton_accion.GetComponentInChildren<Button>().interactable = true;
        Menu_Acciones.SetActive(false);
        Menu_Desplegable.SetActive(false);
        Menu_Cruz.GetComponent<CruzSantaMarta>().DestruirCruces();
        Menu_Cruz.SetActive(false);
        brujula.brujula_activa = false;

        Menu_Analizar.SetActive(false);

        Menu_Cebo.SetActive(true);

        accion_botones.setAccionSprite(3);

    }

    //Activa el menú de la acción Análisis
    public void Onclick_Analizar()
    {
        PlanoCruz.SetActive(false);
        flechas_brujula = GameObject.FindGameObjectsWithTag("Flecha_Brujula");
        foreach(GameObject flecha in flechas_brujula)
        {
            flecha.GetComponent<Direccion_flecha>().activada = false;
        }
        Destroy(GameObject.FindGameObjectWithTag("Cruz"));
        Menu_Interactuar.SetActive(false);
        Menu_Ayuda.SetActive(false);
        Boton_accion.SetActive(false);
        Menu_Acciones.SetActive(false);
        Menu_Desplegable.SetActive(false);
        Menu_Cruz.GetComponent<CruzSantaMarta>().DestruirCruces();
        Menu_Cruz.SetActive(false);
        brujula.brujula_activa = false;

        Menu_Cebo.SetActive(false);

        Menu_Analizar.SetActive(true);
        Menu_Analizar.GetComponentInChildren<BarraAnalisis>().Iniciar();
    }

    //Activa el menú de la acción Interactuar
    public void Onclick_Interactuar()
    {
        PlanoCruz.SetActive(false);
        flechas_brujula = GameObject.FindGameObjectsWithTag("Flecha_Brujula");
        foreach(GameObject flecha in flechas_brujula)
        {
            flecha.GetComponent<Direccion_flecha>().activada = false;
        }
        Destroy(GameObject.FindGameObjectWithTag("Cruz"));

        Menu_Ayuda.SetActive(false);
        Boton_accion.SetActive(true);
        Menu_Interactuar.SetActive(true);
        Menu_Acciones.SetActive(false);
        Menu_Desplegable.SetActive(false);
        Menu_Cruz.GetComponent<CruzSantaMarta>().DestruirCruces();
        Menu_Cruz.SetActive(false);
        brujula.brujula_activa = false;

        Menu_Analizar.SetActive(false);

        Menu_Cebo.SetActive(false);

        accion_botones.setAccionSprite(1);

    }

    //Activa el menú de la acción Brújula
    public void Onclick_Brujula()
    {
        PlanoCruz.SetActive(false);
        brujula.brujula_activa = true;
        flechas_brujula = GameObject.FindGameObjectsWithTag("Flecha_Brujula");
        foreach(GameObject flecha in flechas_brujula)
        {
            flecha.GetComponent<Direccion_flecha>().activada = true;
        }
        Destroy(GameObject.FindGameObjectWithTag("Cruz"));
        Menu_Interactuar.SetActive(false);
        Menu_Ayuda.SetActive(false);
        Boton_accion.SetActive(false);
        Menu_Acciones.SetActive(false);
        Menu_Desplegable.SetActive(false);
        Menu_Cruz.GetComponent<CruzSantaMarta>().DestruirCruces();
        Menu_Cruz.SetActive(false);

        Menu_Analizar.SetActive(false);

        Menu_Cebo.SetActive(false);
    }

    //Activa el menú de la acción Cruz Santa Marta
    public void Onclick_Cruz()
    {
        PlanoCruz.SetActive(true);
        flechas_brujula = GameObject.FindGameObjectsWithTag("Flecha_Brujula");
        foreach(GameObject flecha in flechas_brujula)
        {
            flecha.GetComponent<Direccion_flecha>().activada = false;
        }

        Menu_Ayuda.SetActive(false);
        Menu_Interactuar.SetActive(false);
        Boton_accion.SetActive(false);
        Menu_Acciones.SetActive(false);
        Menu_Desplegable.SetActive(false);
        Menu_Cruz.GetComponent<CruzSantaMarta>().DestruirCruces();
        Menu_Cruz.SetActive(true);
        brujula.brujula_activa = false;
        Menu_Analizar.SetActive(false);

        Menu_Cebo.SetActive(false);
    }
}