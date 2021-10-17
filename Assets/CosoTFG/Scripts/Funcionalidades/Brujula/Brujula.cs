using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brujula : MonoBehaviour
{

    
    public GameObject flecha_dir;

    public GameObject panel_info;

    public bool brujula_activa;
    public int activarpanel;

    void Awake() {
        activarpanel = 0;
        brujula_activa = false;
    }

    // Update is called once per frame
    void Update()
    {
        activarpanel = 0;
        this.transform.position = Camera.main.transform.position;

        if(brujula_activa)
        {
            foreach(GameObject f in GameObject.FindGameObjectsWithTag("Flecha_Brujula"))
            {
                if(f.GetComponent<Direccion_flecha>().cerca)
                {
                    
                    activarpanel++;
                }
            }

            if(activarpanel > 0)
            {
                ActivarPanelInfo();
            }

            else
            {
                DesactivarPanelInfo();
            }
        }
        else{
            DesactivarPanelInfo();
        } 
    }

    public void addObjetivo(GameObject target)
    {
        GameObject flecha = Instantiate(flecha_dir, new Vector3(0,0,0), Quaternion.identity) as GameObject;
        flecha.transform.parent = this.transform;
        flecha.transform.localPosition = new Vector3(0, -0.25f, 0);
        flecha.GetComponent<Direccion_flecha>().SetObjetivo(target.transform);
    }

    public void deleteObjetivos()
    {
        GameObject[] flechas = GameObject.FindGameObjectsWithTag("Flecha_Brujula");
        foreach( GameObject f_go in flechas)
        {
            Destroy(f_go);
        }
    }

    public void ActivarPanelInfo()
    {
        panel_info.SetActive(true);
    }

    public void DesactivarPanelInfo()
    {
        panel_info.SetActive(false);
    }



}
