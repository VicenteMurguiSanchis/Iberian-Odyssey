using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analizador : MonoBehaviour
{

    private float distancia_analisis = 50;
    public Inventario menu_bestias;
    private BarraAnalisis bar_analisis;
    private int last_id;
    // Start is called before the first frame update
    void Start()
    {
        bar_analisis = FindObjectOfType<BarraAnalisis>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distancia_analisis))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward*distancia_analisis, Color.red);
            if(hit.collider.tag == "Trenti_Boss" || hit.collider.tag == "Trenti" || hit.collider.tag == "Musgosu" || 
                hit.collider.tag == "Cuelebre" || hit.collider.tag == "Tarasca")
            {
                bar_analisis.Analizar();
                if(bar_analisis.analizado)
                {
                    last_id = hit.collider.GetComponent<Bestia>().id;
                    menu_bestias.AddEntradaBestiario(last_id);
                    switch(last_id)
                    {
                        case 1:
                            PlayerPrefs.SetInt("registro_Trenti",1);
                            break;
                        case 2:
                            PlayerPrefs.SetInt("registro_Musgosu",1);
                            break;
                        case 3:
                            PlayerPrefs.SetInt("registro_Cuelebre",1);
                            break;
                        case 4:
                            PlayerPrefs.SetInt("registro_Tarasca",1);
                            break;
                    }
                }
            }

            else
            {
                bar_analisis.StopAnalizar();
            }
        }
        else
        {
            bar_analisis.StopAnalizar();
        }
    }
}
