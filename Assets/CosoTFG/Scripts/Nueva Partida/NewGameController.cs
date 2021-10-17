using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameController : MonoBehaviour
{
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;
    private void Awake() {
        PlayerPrefs.SetInt("num_mision",1);
        PlayerPrefs.SetInt("registro_Tarasca",0);
        PlayerPrefs.SetInt("registro_Trenti",0);
        PlayerPrefs.SetInt("registro_Musgosu",0);
        PlayerPrefs.SetInt("registro_Cuelebre",0);

        PlayerPrefs.SetInt("registro_PonerCebo",0);
        PlayerPrefs.SetInt("registro_Cruz",0);

        imagen1.enabled = false;
        imagen2.enabled = false;
        imagen3.enabled = false;
    }

    public void EmpezarPartida()
    {
        PlayerPrefs.SetInt("Juego_Nuevo",1);
        SceneManager.LoadScene("Juego");
    }

    //Activa la primera imagen
    public void EncenderImagen1()
    {
        imagen1.enabled = true;
    }

    //Activa la segunda imagen
    public void EncenderImagen2()
    {
        imagen2.enabled = true;
    }

    //Activa la tercera imagen
    public void EncenderImagen3()
    {
        imagen3.enabled = true;
    }
}
