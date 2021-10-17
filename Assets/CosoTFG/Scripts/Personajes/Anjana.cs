using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Anjana : Bestia
{
    //private Vector3 camara_pos;

    private int mision_actual;

    private float vel = 0.25f;

    private bool descenso, ascenso;

    public GameObject Anajana_GO;


    

    // Start is called before the first frame update
    void Start()
    {
        dialogo = GetComponentInChildren<Flowchart>();
        ComenzarDialogo();
        descenso = true;
        ascenso = false;
        camara_pos = Camera.main.transform.position;
        this.transform.localPosition = new Vector3(0,0.75f,0);
        mision_actual = FindObjectOfType<Misiones_Controller>().misionActual;

        switch(mision_actual)
        {
            case 1:
                dialogo.ExecuteBlock("Mision1");
                break;
            case 2:
                dialogo.ExecuteBlock("Mision2");
                break;
            case 3:
                dialogo.ExecuteBlock("Mision3");
                break;
            case 4:
                dialogo.ExecuteBlock("Mision4");
                break;
            case 5:
                if(PlayerPrefs.GetInt("registro_Cuelebre",0) == 1)
                {
                    dialogo.ExecuteBlock("Mision5_2");
                }
                else{
                    dialogo.ExecuteBlock("Mision5");
                }
                break;
            case 6:
                dialogo.ExecuteBlock("Mision6");
                break;
            case 7:
                dialogo.ExecuteBlock("Final");
                break;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if(descenso)
        {
            this.transform.localPosition = new Vector3(0, this.transform.localPosition.y + -(vel)*Time.deltaTime, 0);
            if(this.transform.localPosition.y <= 0)
                descenso = false;
        }

        else if(ascenso)
        {
            this.transform.localPosition = new Vector3(0, this.transform.localPosition.y + (vel)*Time.deltaTime, 0);
            if(this.transform.localPosition.y >= 1)
            {
                ascenso = false;
                Destroy(Anajana_GO);
            }
        }

        MirarJugador();
    }

    public void Irse() 
    {
        ascenso = true;
    }

    public void Finalizar()
    {
        SceneManager.LoadScene("Final");
    }
}
