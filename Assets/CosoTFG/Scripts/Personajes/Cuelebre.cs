using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Cuelebre : Bestia
{

    private float vel;
    public bool cazando;
    public bool comiendo;
    private Transform pos_cofre;
    private Transform pos_Cebo;
    private Vector3 dir_ida;
    private Vector3 dir_vuelta;

    private void Awake() {
        animator = this.GetComponentInChildren<Animator>();
        pos_cofre = GameObject.FindGameObjectWithTag("Cofre").transform;    
        dialogo = this.GetComponentInChildren<Flowchart>();
        cazando = false;
        vel = 5;
    }

    void Update()
    {
        DistanciaRender();
        MirarJugador();
        if(cazando)
        {
            if(pos_Cebo != null)
            {  
                if(!comiendo)
                {
                    animator.SetBool("fly", true);
                    var rotacion = pos_Cebo.position - transform.position;
                    rotacion.y = 0;
                    var rotacion_Quaternion = Quaternion.LookRotation(rotacion);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotacion_Quaternion, 1);
                    this.transform.position = new Vector3(this.transform.position.x + (vel * dir_ida.x) * Time.deltaTime, this.transform.position.y, this.transform.position.z + (vel * dir_ida.z) * Time.deltaTime);
                }

                else
                {
                    animator.SetBool("fly", false);
                }
            }

            else
            {
                animator.SetBool("fly", true);
                comiendo = false;
                var rotacion = pos_cofre.position - transform.position;
                rotacion.y = 0;
                var rotacion_Quaternion = Quaternion.LookRotation(rotacion);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacion_Quaternion, 1);
                this.transform.position = new Vector3(this.transform.position.x + (vel * dir_vuelta.x)*Time.deltaTime, this.transform.position.y, this.transform.position.z + (vel * dir_vuelta.z)*Time.deltaTime);
                if((Mathf.Sqrt(Mathf.Pow(this.transform.position.x - pos_cofre.position.x,2) + Mathf.Pow(this.transform.position.z - pos_cofre.position.z,2))) <= 10f)
                {
                    cazando = false;
                }
            }
        }
    }

    public void SeguirCebo()
    {
        cazando = true;
        pos_Cebo = GameObject.FindGameObjectWithTag("Cebo").transform;
        float mod_ida = Mathf.Sqrt(Mathf.Pow(pos_Cebo.position.x - this.transform.position.x,2)+Mathf.Pow(pos_Cebo.position.z - this.transform.position.z,2));
        dir_ida = new Vector3(((pos_Cebo.position.x - this.transform.position.x)/mod_ida), this.transform.position.y,((pos_Cebo.position.z - this.transform.position.z)/mod_ida));
        float mod_vuelta = Mathf.Sqrt(Mathf.Pow(pos_cofre.position.x - this.transform.position.x,2)+Mathf.Pow(pos_cofre.position.z - this.transform.position.z,2));
        dir_vuelta = new Vector3(-((this.transform.position.x - pos_cofre.position.x)/mod_vuelta), this.transform.position.y,-((this.transform.position.z - pos_cofre.position.z)/mod_vuelta));
    }

    public void Dialogo()
    {
        if(!cazando)
        {
            ComenzarDialogo();
            dialogo.ExecuteBlock("Dialogo_Cuelebre");
        }
            
    }
}
