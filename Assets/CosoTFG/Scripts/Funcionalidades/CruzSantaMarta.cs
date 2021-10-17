using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzSantaMarta : MonoBehaviour
{
    public GameObject cruzPrefab;
    private GameObject cruz;

    private void Awake() {
        cruz = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var crucesRezagadas = GameObject.FindGameObjectsWithTag("Cruz");
            foreach(GameObject c in crucesRezagadas)
            {
                Destroy(c);
            }
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.tag == "CruzZ")
                {
                    cruz = Instantiate(cruzPrefab, hit.point, new Quaternion(0,0,0,0)) as GameObject;
                    cruz.transform.parent = Camera.main.transform;
                    cruz.transform.localRotation = new Quaternion(0,0,0,0);
                }
            }
        }

        else if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.tag == "CruzZ")
                {
                    cruz.transform.position = hit.point;
                    cruz.transform.localRotation = new Quaternion(0,0,0,0);
                }
            }
        }

        else if(Input.GetMouseButtonUp(0))
        {
            Destroy(cruz);
        }
    }

    public void DestruirCruces()
    {
        GameObject[] cruces = GameObject.FindGameObjectsWithTag("Cruz");
        foreach (GameObject cruz in cruces)
        {
            Destroy(cruz);
        }
    }
}
