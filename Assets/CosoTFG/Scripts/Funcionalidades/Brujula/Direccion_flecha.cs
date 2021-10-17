using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direccion_flecha : MonoBehaviour
{
    public Transform objetivo;

    private float dis_objetivo;

    public bool activada;

    public bool cerca;

    void Awake() {
        cerca = false;
        activada = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(activada)
        {
            if(!objetivo)
                Destroy(this.gameObject);

            else
            {
                dis_objetivo = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - objetivo.position.x,2) + 
                                          Mathf.Pow(this.transform.position.z - objetivo.position.z,2));

                if(dis_objetivo <= 50)
                {
                    cerca = true;
                    var meshes = this.GetComponentsInChildren<MeshRenderer>();
                    foreach(MeshRenderer m in meshes)
                    {
                        m.enabled = false;
                    }
                }
                else{
                    cerca = false;
                    var meshes = this.GetComponentsInChildren<MeshRenderer>();
                    foreach(MeshRenderer m in meshes)
                    {
                        m.enabled = true;
                    }
                    var rotacion = objetivo.position - transform.position;
                    rotacion.y = 0;
                    var rotacion_Quaternion = Quaternion.LookRotation(rotacion);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotacion_Quaternion, 1);
                }                
            }
        }

        else{
            var meshes = this.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer m in meshes)
            {
                m.enabled = false;
            }
        }
        
    }

    public void SetObjetivo(Transform t)
    {
        objetivo = t;
    }

}
