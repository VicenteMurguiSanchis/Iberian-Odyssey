using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu_Juego : MonoBehaviour
{
    public GameObject Menu_Desplegable;

    public GameObject Menu_Acciones;

    public GameObject Menu_Bestiario;

    public GameObject Pagina_Bestiario;

    public GameObject Menu_Cebo;
    
    public GameObject Menu_Ayuda;

    public GameObject Menu_Analisis;

    public GameObject Menu_Interactuador;

    public Boton_Acciones accion_boton;

    public Button boton_menu;

    public GameObject boton_accion;

    public GameObject menu_Salir;

    public GameObject Cruz_Controller;

    public Brujula brujula;

    public Image NewHelp;

    private bool cuelebre_help;

    private GameObject[] flechas_brujula;

    //Inicializa la clase con la variable cuelebre_help a falso
    void Start()
    {
        cuelebre_help = false;
    }

    //Si se cumplen una serie de requisitos, se mostrará un indicador de que hay una nueva ayuda en el menu de ayuda
    void Update()
    {
        if(PlayerPrefs.GetInt("registro_Cuelebre",0) == 1 && PlayerPrefs.GetInt("num_mision",1) == 5 && !cuelebre_help)
        {
            NewHelp.enabled = true;
        }
    }

    //Abre y cierra el menú desplegable principal cuando se aprieta el botón "Menu"
    public void OnClickMenuButton()
    {
        Cruz_Controller.GetComponent<CruzSantaMarta>().DestruirCruces();
        Menu_Acciones.SetActive(false);
        Menu_Bestiario.SetActive(false);
        Pagina_Bestiario.SetActive(false);
        if(Menu_Desplegable.activeSelf)
        {
            Menu_Desplegable.SetActive(false);
        }

        else{
            Menu_Desplegable.SetActive(true);
        }
    }

    //Abre y cierra el menú desplegable del listado de acciones cuando se aprieta el botón "Acciones"
    public void OnClick_Acciones()
    {
        Cruz_Controller.GetComponent<CruzSantaMarta>().DestruirCruces();
        Menu_Bestiario.SetActive(false);
        Pagina_Bestiario.SetActive(false);
        if(Menu_Acciones.activeSelf)
        {
            Menu_Acciones.SetActive(false);
        }

        else{
            Menu_Acciones.SetActive(true);
        }
    }

    //Abre y cierra el menú desplegable del bestiario cuando se aprieta el botón "Bestiario"
    public void OnClick_Bestiario()
    {
        Cruz_Controller.GetComponent<CruzSantaMarta>().DestruirCruces();    
        Menu_Acciones.SetActive(false);
        Pagina_Bestiario.SetActive(false);
        if(Menu_Bestiario.activeSelf)
        {
            Menu_Bestiario.SetActive(false);
        }

        else{
            Menu_Bestiario.SetActive(true);
        }
    }

    //Abre y cierra el menú de ayuda cuando se aprieta el botón "Ayuda"
    public void OnClick_Ayuda()
    {
        Cruz_Controller.GetComponent<CruzSantaMarta>().DestruirCruces();
        OcultarNuevaAyuda();
        Cruz_Controller.SetActive(false);
        Menu_Bestiario.SetActive(false);
        Menu_Cebo.SetActive(false);
        Menu_Interactuador.SetActive(false);
        Menu_Acciones.SetActive(false);
        Pagina_Bestiario.SetActive(false);
        Menu_Interactuador.SetActive(false);
        Menu_Desplegable.SetActive(false);
        Menu_Analisis.SetActive(false);
        flechas_brujula = GameObject.FindGameObjectsWithTag("Flecha_Brujula");
        foreach(GameObject flecha in flechas_brujula)
        {
            flecha.GetComponent<Direccion_flecha>().activada = false;
        }
        if(Menu_Ayuda.activeSelf)
        {  
            Menu_Ayuda.SetActive(false);
            boton_accion.SetActive(false);
        }

        else{
            Menu_Ayuda.SetActive(true);
            boton_accion.SetActive(true);
            boton_accion.GetComponentInChildren<Button>().interactable = true;
            accion_boton.setAccionSprite(6);
            
        }
    }

    //Sale a la escena de inicio
    public void Quit()
    {
        SceneManager.LoadScene("Inicio");
    }

    //Abre y cierra el menú de salir cuando se aprieta el botón "Salir"
    public void Menu_Salir()
    {
        Cruz_Controller.GetComponent<CruzSantaMarta>().DestruirCruces();
        Menu_Bestiario.SetActive(false);
        Menu_Cebo.SetActive(false);
        Menu_Acciones.SetActive(false);
        Pagina_Bestiario.SetActive(false);
        Menu_Ayuda.SetActive(false);
        Menu_Desplegable.SetActive(false);
        Menu_Analisis.SetActive(false);
        boton_accion.SetActive(false);
        brujula.brujula_activa = false;
        flechas_brujula = GameObject.FindGameObjectsWithTag("Flecha_Brujula");
        foreach(GameObject flecha in flechas_brujula)
        {
            flecha.GetComponent<Direccion_flecha>().activada = false;
        }
        if(menu_Salir.activeSelf)
        {
            menu_Salir.SetActive(false);
           
        }

        else{
            menu_Salir.SetActive(true);
            
        }
    }

    //Hace que aparezca un indicador de que hay ayuda nueva en el menú de ayuda.
    public void MostrarNuevaAyuda()
    {
        NewHelp.enabled = true;
    }

    //Hace que el indicador de ayuda nueva desaparezca
    public void OcultarNuevaAyuda()
    {
        NewHelp.enabled = false;
        if(PlayerPrefs.GetInt("registro_Cuelebre",0) == 1 && PlayerPrefs.GetInt("num_mision",1) == 5 && !cuelebre_help)
        {
            cuelebre_help = true;
        }
    }
    
}

