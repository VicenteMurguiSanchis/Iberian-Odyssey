using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interactuador : MonoBehaviour
{
    private float distancia_interactuador_larga = 45;
    private float distancia_interactuador_media = 40;
    private float distancia_interactuador_corta = 15;
    public Button boton_accion;


    private void FixedUpdate()
    {
        RaycastHit hitlargo;
        RaycastHit hitmedio;
        RaycastHit hitcorto;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitlargo, distancia_interactuador_larga))
        {
            //Lanzamiento del Raycast de larga distancia
            if(hitlargo.collider.tag == "Cuelebre" || hitlargo.collider.tag == "Tarasca")
            {
                boton_accion.interactable = true;
            }

            else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitmedio, distancia_interactuador_media))
            {
                //Lanzamiento del Raycast de media distancia
                if(hitmedio.collider.tag == "Cofre" || hitmedio.collider.tag == "Trenti")
                {
                    boton_accion.interactable = true;
                }

                else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitcorto, distancia_interactuador_corta))
                {
                    //Lanzamiento del Raycast de corta distancia
                    if(hitcorto.collider.tag == "Trenti_Boss" || hitcorto.collider.tag == "Musgosu")
                    {
                        boton_accion.interactable = true;
                    }
                }

                else
                {
                    boton_accion.interactable = false;
                }
            }

            else
            {
                boton_accion.interactable = false;
            }
        }

        else
        {
            boton_accion.interactable = false;
        }
    }

    public void Interactuar() 
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distancia_interactuador_larga))
        {
            if(hit.collider.tag == "Trenti_Boss")
            {
                Debug.Log("Interctuar con Trenti_Boss");
                hit.collider.GetComponent<Trenti_Boss>().Dialogo(); 
            }
            if(hit.collider.tag == "Trenti")
            {
                Debug.Log("Interctuar con Trenti");
                hit.collider.GetComponent<Trenti>().Dialogo(); 
            }
            if(hit.collider.tag == "Musgosu")
            {
                Debug.Log("Interctuar con Musgosu");
                hit.collider.GetComponent<Musgosu>().Dialogo(); 
            }
            if(hit.collider.tag == "Cuelebre")
            {
                Debug.Log("Interactuar con Cuelebre");
                hit.collider.GetComponent<Cuelebre>().Dialogo();
            }
            if(hit.collider.tag == "Tarasca")
            {
                Debug.Log("Interactuar con Tarasca");
                hit.collider.GetComponent<Tarasca>().Dialogo();
            }
            if(hit.collider.tag == "Cofre")
            {
                hit.collider.GetComponent<Cofre_Cuelebre>().Abrir();
            }
        }        
    }
}
