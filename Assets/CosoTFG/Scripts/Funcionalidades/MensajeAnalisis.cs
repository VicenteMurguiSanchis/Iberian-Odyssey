using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajeAnalisis : MonoBehaviour
{
    private Text text;

    private int num_Trentis;

    private void Awake() {
        text = this.GetComponentInChildren<Text>();
        num_Trentis = 4;
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BestiarioActualizado()
    {
        text.text = "Se ha añadido una nueva entrada al bestiario";
    }

    public void EntradaExistente()
    {
        text.text = "Ya hay una entrada en el bestiario de este ser";
    }

    public void CuentaTrenti()
    {
        text.text = "Trentis " + (num_Trentis - ((GameObject.FindGameObjectsWithTag("Trenti").Length)-1)) + " / " + num_Trentis;
        if((num_Trentis - ((GameObject.FindGameObjectsWithTag("Trenti").Length)-1)) == num_Trentis)
        {
            GameObject.FindObjectOfType<Misiones_Controller>().Cambiar_Mision();
        }
    }

}
