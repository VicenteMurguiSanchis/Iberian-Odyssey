using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenFinal : MonoBehaviour
{

    public GameObject ordenFinal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var anjana = FindObjectOfType<Anjana>();
        if(anjana != null)
        {
            ordenFinal.SetActive(false);
        }
    }
}
