using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Bestia : MonoBehaviour
{

    public int id;
    public float dist_renderizado;
    public Flowchart dialogo;
    public Vector3 camara_pos;
    public Animator animator;
    public bool dialogando;

    public void DistanciaRender()
    {
       if(Mathf.Sqrt(Mathf.Pow(this.transform.position.x - Camera.main.transform.position.x,2)+Mathf.Pow(this.transform.position.z - Camera.main.transform.position.z,2)) >= dist_renderizado)
       {
            if(this.GetComponentInChildren<SkinnedMeshRenderer>())
            {
                
                var meshes = this.GetComponentsInChildren<SkinnedMeshRenderer>();
                foreach (var m in meshes)
                {
                    m.enabled = false;
                }
            } 
            else
            {
                var meshes = this.GetComponentsInChildren<MeshRenderer>();
                foreach (var m in meshes)
                {
                    m.enabled = false;
                }
            }        
       }

       else{
           if(this.GetComponentInChildren<SkinnedMeshRenderer>())
           {
               var meshes = this.GetComponentsInChildren<SkinnedMeshRenderer>();
                foreach (var m in meshes)
                {
                    m.enabled = true;
                }
           }
           else
            {
                var meshes = this.GetComponentsInChildren<MeshRenderer>();
                foreach (var m in meshes)
                {
                    m.enabled = true;
                }
            }
       }
    }

    public void MirarJugador()
    {
        if(dialogando)
        {
            camara_pos = Camera.main.transform.position;
            var rotacion = camara_pos - transform.position;
            rotacion.y = 0;
            var rotacion_Quaternion = Quaternion.LookRotation(rotacion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion_Quaternion, 1);
        }
    }

    public void ComenzarDialogo()
    {
        dialogando = true;
    }

    public void TerminarDialogo()
    {
        dialogando = false;
    }
}
