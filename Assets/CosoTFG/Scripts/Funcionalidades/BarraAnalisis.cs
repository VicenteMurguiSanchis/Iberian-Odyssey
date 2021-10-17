using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraAnalisis : MonoBehaviour
{

    public bool analizando;
    private float valor_actual;

    private float velocidad = 25f;
    private float vel_descenso = 100f;

    public bool analizado;

    // Start is called before the first frame update

    private void Awake() {
        valor_actual = 0;
        analizando = false;
        analizado = false;
        transform.localScale = new Vector3(1,0,1);
    }

    // Update is called once per frame
    void Update()
    {
        if(analizando && !analizado)
        {
            
            valor_actual = (valor_actual + (velocidad*Time.deltaTime));
            if(valor_actual >= 100)
            {
                valor_actual = 100;
                analizado = true;
            }
            transform.localScale = new Vector3(1,valor_actual/100,1);
        }
        else{
            if(valor_actual <= 0)
            {
                analizado = false;
                valor_actual = 0f;
            }
            else{
                valor_actual = (valor_actual - (vel_descenso*Time.deltaTime));
            }
            transform.localScale = new Vector3(1,valor_actual/100,1);
        }
    }

    public void Analizar()
    {
        analizando = true;
    }

    public void StopAnalizar()
    {
        analizando = false;
    }

    public void Iniciar()
    {
        valor_actual = 0;
        analizando = false;
        analizado = false;
        transform.localScale = new Vector3(1,0,1);
    }
}
