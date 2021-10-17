using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Principal : MonoBehaviour
{

    public Button boton_continue;
    public GameObject menu_creditos;

  
    void Awake()
    {
        if(PlayerPrefs.GetInt("Juego_Nuevo",0) == 0)
        {
            boton_continue.interactable = false;
        }

        else{
            boton_continue.interactable = true;
        }
    }


    public void Play() 
    {
        PlayerPrefs.SetInt("Juego_Nuevo", 1);
        SceneManager.LoadScene("Juego");
    }

    public void NewGame() 
    {
        PlayerPrefs.SetInt("Juego_Nuevo",0);
        SceneManager.LoadScene("NuevaPartida");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        if(menu_creditos.activeSelf)
        {
            menu_creditos.SetActive(false);
        }

        else{
            menu_creditos.SetActive(true);
        }
    }

    public void Continuar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Regresar()
    {
        SceneManager.LoadScene("Inicio");
    }
}
