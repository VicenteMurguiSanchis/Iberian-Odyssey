using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory System/Bestiario")]
public class Bestiario : ScriptableObject
{
    public List<Entrada_Bestia> bestias = new List<Entrada_Bestia>();

    public Entrada_Bestia FindEntrada_Bestia(int id) {
        foreach (Entrada_Bestia b in bestias)
        {
            if (b.id == id)
            {
                return b;
            }
        }
        return null;
    }
}

[System.Serializable]
public class Entrada_Bestia
{
    public int id;
    public string name;
    public Sprite imagen;
    public Sprite boton_imagen;
    public string descripcion;
}
