using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzController : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, 45f))
        {
            if(hit.collider.tag == "Tarasca")
            {
                FindObjectOfType<Tarasca>().Amenazado();
            }
        }
    }

}
