using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Listado de acciones")]
public class ListadoAcciones : ScriptableObject
{
     public List<Accion> acciones = new List<Accion>();

    public Accion FindAcciones(int id) {
        foreach (Accion a in acciones)
        {
            if (a.id == id)
            {
                return a;
            }
        }
        return null;
    }
}

[System.Serializable]
public class Accion
{
    public int id;
    public string name;
    public Sprite boton_imagen;
}
