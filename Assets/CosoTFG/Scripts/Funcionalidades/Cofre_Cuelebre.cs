using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Cofre_Cuelebre : MonoBehaviour
{
    private float dist_culebre;

    private GameObject cuelebre;

    public GameObject chesOpened;

    public GameObject chesClosed;

    private bool custodiado;

    public bool abierto;

    private Flowchart dialogo;

    private void Awake() {
        cuelebre = GameObject.FindGameObjectWithTag("Cuelebre");
        custodiado = true;
        abierto = false;
        dialogo = GetComponentInChildren<Flowchart>();
    }

    void Update()
    {
        dist_culebre = Mathf.Sqrt(Mathf.Pow(cuelebre.transform.position.x - this.transform.position.x,2)+Mathf.Pow(cuelebre.transform.position.z - this.transform.position.z,2));
        if(dist_culebre > 5f)
        {
            custodiado = false;
        }
        else{
            custodiado = true;
        }


        if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - Camera.main.transform.position.x, 2) + Mathf.Pow(this.transform.position.z - Camera.main.transform.position.z, 2)) >= 80f)
        {
            if (this.GetComponentInChildren<MeshRenderer>())
            {
                var meshes = this.GetComponentsInChildren<MeshRenderer>();
                foreach (var m in meshes)
                {
                    m.enabled = false;
                }
            }
        }
        else
        {
            if (this.GetComponentInChildren<MeshRenderer>())
            {
                var meshes = this.GetComponentsInChildren<MeshRenderer>();
                foreach (var m in meshes)
                {
                    m.enabled = true;
                }
            }
        }
    }

    public void Abrir()
    {
        if(!abierto)
        {
            GameObject opend = Instantiate(chesOpened, new Vector3(chesClosed.transform.position.x, chesClosed.transform.position.y, chesClosed.transform.position.z) , Quaternion.Euler(0,0,0)) as GameObject;
            opend.transform.parent = this.gameObject.transform;
            opend.transform.position = new Vector3(chesClosed.transform.position.x, chesClosed.transform.position.y, chesClosed.transform.position.z);
            Destroy(chesClosed);
            opend.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            dialogo.ExecuteBlock("Abierto");
            abierto = true;
        }
        else{
            dialogo.ExecuteBlock("Vacio");
        }

    }

    public void Activar_Cruz()
    {
        GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>().AddEntradaAccion(4);
        PlayerPrefs.SetInt("registro_Cruz",1);
        FindObjectOfType<Misiones_Controller>().Cambiar_Mision();
    }
}
