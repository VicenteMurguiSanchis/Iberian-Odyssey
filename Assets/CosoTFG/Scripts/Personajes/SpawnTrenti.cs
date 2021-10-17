using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrenti : MonoBehaviour
{

    public GameObject trenti;

    private int num_trentis = 2;

    private float radio = 40;

    public GameObject target;
    void Start()
    {
        CrearTrentis();
    }

    void Update()
    {
        foreach(Trenti t in this.GetComponentsInChildren<Trenti>())
        {
            if(t.distancia < 0.5f)
            {
                Destroy(t.target);
                Vector3 pos_trenti = new Vector3(Random.Range(this.transform.position.x - radio, this.transform.position.x + radio), this.transform.position.y, Random.Range(this.transform.position.z - radio, this.transform.position.z + radio));
                GameObject target_obj = Instantiate(target,pos_trenti,Quaternion.identity) as GameObject;
                target_obj.transform.parent = this.transform;
                t.target = target_obj;
            }
        }


        if(this.GetComponentsInChildren<Trenti>().Length != num_trentis)
        {
            num_trentis = this.GetComponentsInChildren<Trenti>().Length;
            if(FindObjectOfType<Misiones_Controller>().misionActual == 2 && num_trentis == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void CrearTrentis()
    {
        for(int i=1; i<=num_trentis;i++)
        {
            Vector3 pos_trenti = new Vector3(Random.Range(this.transform.position.x - radio, this.transform.position.x + radio), -3f, Random.Range(this.transform.position.z - radio, this.transform.position.z + radio));
            GameObject trenti_obj = Instantiate(trenti, pos_trenti, Quaternion.identity) as GameObject;
            trenti_obj.transform.parent = this.transform;
            GameObject target_obj = Instantiate(target, this.transform.position,Quaternion.identity) as GameObject;
            target_obj.transform.parent = this.transform;
            trenti_obj.transform.position = new Vector3(Random.Range(this.transform.position.x - radio, this.transform.position.x + radio), 0, Random.Range(this.transform.position.z - radio, this.transform.position.z + radio));
            target_obj.transform.position = new Vector3(Random.Range(this.transform.position.x - radio, this.transform.position.x + radio), 0, Random.Range(this.transform.position.z - radio, this.transform.position.z + radio));
            trenti_obj.GetComponent<Trenti>().target = target_obj;
        }
    }
}
