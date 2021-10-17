using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fungus;

public class Trenti : Bestia
{

    public GameObject target;

    public float vel;

    public GameObject Cuenta_Trenti;

    public float distancia;

    void Awake() {
        animator = GetComponent<Animator>();
        
        dialogo = GetComponentInChildren<Flowchart>();

        vel = 2;
        this.transform.position = new Vector3(this.transform.position.x, -3, this.transform.position.z);
    }

    void Update()
    {
        DistanciaRender();
        distancia = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - target.transform.position.x,2) + Mathf.Pow(this.transform.position.z - target.transform.position.z,2));
        MirarJugador();
        if(!dialogando){
            if(target != null)
            {
                float mod = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - this.transform.position.x,2)+Mathf.Pow(target.transform.position.z - this.transform.position.z,2));
                Vector3 dir_target = new Vector3(((target.transform.position.x - this.transform.position.x)/mod),-3,((target.transform.position.z - this.transform.position.z)/mod));

                this.transform.position = new Vector3(this.transform.position.x + (vel * dir_target.x)*Time.deltaTime, -3, this.transform.position.z + (vel * dir_target.z)*Time.deltaTime);

                var rotacion = target.transform.position - transform.position;

                rotacion.y = 0;

                var rotacion_Quaternion = Quaternion.LookRotation(rotacion);

                transform.rotation = Quaternion.Slerp(transform.rotation, rotacion_Quaternion, 1);
            }
        }

    }

    public void Irse()
    {
        GameObject cuenta = Instantiate(Cuenta_Trenti, new Vector3(0,0,0), Quaternion.identity);
        cuenta.GetComponent<MensajeAnalisis>().CuentaTrenti();
        Destroy(target);
        Destroy(this.gameObject);
    }

    public void Dialogo()
    {
        ComenzarDialogo();
        int comentario = Random.Range(0,6);
        if(FindObjectOfType<Misiones_Controller>().misionActual == 2)
        {
            animator.SetBool("happy",true);
            switch(comentario)
            {
                case 0:
                    dialogo.ExecuteBlock("Respuesta0");
                break;
                case 1:
                    dialogo.ExecuteBlock("Respuesta1");
                break;
                case 2:
                    dialogo.ExecuteBlock("Respuesta2");
                break;
                case 3:
                    dialogo.ExecuteBlock("Respuesta3");
                break;
                case 4:
                    dialogo.ExecuteBlock("Respuesta4");
                break;
                case 5:
                    dialogo.ExecuteBlock("Respuesta5");
                break;
            }
        }

        else
        {
            animator.SetBool("cry",true);
            switch(comentario)
            {
                case 0:
                    dialogo.ExecuteBlock("Comentario0");
                break;
                case 1:
                    dialogo.ExecuteBlock("Comentario1");
                break;
                case 2:
                    dialogo.ExecuteBlock("Comentario2");
                break;
                case 3:
                    dialogo.ExecuteBlock("Comentario3");
                break;
                case 4:
                    dialogo.ExecuteBlock("Comentario4");
                break;
                case 5:
                    dialogo.ExecuteBlock("Comentario5");
                break;
            }
        }
        
    }

    public void QuitarParado()
    {
        TerminarDialogo();
        animator.SetBool("cry",false);
    }
}
