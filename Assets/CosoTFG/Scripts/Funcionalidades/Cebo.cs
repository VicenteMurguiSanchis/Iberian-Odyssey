using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cebo : MonoBehaviour
{   
    private float dist_cuelebre;

    private GameObject cuelebre;

    void Update()
    {
        cuelebre = GameObject.FindGameObjectWithTag("Cuelebre");
        cuelebre.GetComponent<Cuelebre>().SeguirCebo();

        if(cuelebre != null)
        {
            dist_cuelebre = Mathf.Sqrt(Mathf.Pow(cuelebre.transform.position.x - this.transform.position.x,2) + 
                            Mathf.Pow(cuelebre.transform.position.z - this.transform.position.z,2));
            if(dist_cuelebre < 5f)
            {
                cuelebre.GetComponent<Cuelebre>().comiendo = true;
                Destroy(this.gameObject,60f);
            }
        }
        
    }
}
