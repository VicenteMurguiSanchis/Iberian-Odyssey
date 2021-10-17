using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public Bestiario bestiario;
    public ListadoAcciones acciones;
    public Image imagenEntrada;
    public SlotInfo slotInfo;
    public PaginaBestiario paginaBestiario;

    public Acciones accionesScript;

    public void SetUp(int id)
    {
        slotInfo = new SlotInfo();
        slotInfo.id = id;
        slotInfo.EmptySlot();
    }

    public void UpdateUI()
    {
        if(slotInfo.isEmpty)
        {
            imagenEntrada.sprite = null;
            imagenEntrada.enabled = false;
            this.GetComponent<Button>().interactable = false;
        }

        else
        {
            Button boton_slot = this.GetComponent<Button>();
            boton_slot.interactable = true;

            if(bestiario != null)
            {
                imagenEntrada.sprite = bestiario.FindEntrada_Bestia(slotInfo.id).boton_imagen;
                paginaBestiario = (PaginaBestiario) FindObjectOfType(typeof(PaginaBestiario));
                boton_slot.onClick.AddListener(OpenPageBest);
            }
            else
            {
                imagenEntrada.sprite = acciones.FindAcciones(slotInfo.id).boton_imagen;
                accionesScript = (Acciones) FindObjectOfType(typeof(Acciones));
                boton_slot.onClick.AddListener(ActiveActions);
            }
            

            imagenEntrada.enabled = true;
            
            
        }
    }

    public void OpenPageBest()
    {
        paginaBestiario.AbrirPaginaBestiario(bestiario.FindEntrada_Bestia(slotInfo.id).name, bestiario.FindEntrada_Bestia(slotInfo.id).descripcion, bestiario.FindEntrada_Bestia(slotInfo.id).imagen);
    }

    public void ActiveActions()
    {
        switch(acciones.FindAcciones(slotInfo.id).id)
        {
            case 0:
                accionesScript.Onclick_Interactuar();
                break;
            case 1:
                accionesScript.Onclick_Analizar();
                break;
            case 2:
                accionesScript.Onclick_PonerCebo();
                break;
            case 3:
                accionesScript.Onclick_Brujula();
                break;
            case 4:
                accionesScript.Onclick_Cruz();
                break;
        }
    }
}

    [System.Serializable]
public class SlotInfo
 {
    public int id;
    public bool isEmpty;

    public void EmptySlot()
    {
        isEmpty = true;
    }


}
