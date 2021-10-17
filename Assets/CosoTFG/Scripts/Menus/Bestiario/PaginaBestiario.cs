using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaginaBestiario : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pagina;
    public GameObject Menu_Bestiario;
    public Text nombre_Bestia;
    public Text descripcion;
    public Image img_Bestia;

    public void AbrirPaginaBestiario(string name, string descr, Sprite img)
    {
        pagina.SetActive(true);
        Menu_Bestiario.SetActive(false);
        nombre_Bestia.text = name;
        descripcion.text = descr;
        img_Bestia.sprite = img;

    }
    
}
