using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    [SerializeField]
    private Bestiario bestiario;
    public Transform bestiario_panel;
    [SerializeField]
    private ListadoAcciones acciones;
    public Transform acciones_panel;
    [SerializeField]
    private GameObject slotBestiarioPrefab;
    [SerializeField]
    private GameObject slotAccionesPrefab;
    [SerializeField]
    private List<SlotInfo> slotInfoListBestiario, slotInfoListAcciones;
    [SerializeField]
    private int num_slots;
    private int PosSlotLlenar;
    public GameObject Advertencia;
    
    //Se ejecuta antes del primer frame de refresco
    private void Start() 
    {
        slotInfoListBestiario = new List<SlotInfo>();
        slotInfoListAcciones = new List<SlotInfo>();
        LoadInventario();
    }

    //Carga el bestiario
    private void LoadInventario()
    {
        //Crear slots bestiario
        for(int i = 0; i < num_slots; i++)
        {
            
            GameObject slot = Instantiate<GameObject>(slotBestiarioPrefab, bestiario_panel);
            Slot newSlot = slot.GetComponent<Slot>();
            Button buttonSlot = slot.GetComponent<Button>();
            newSlot.SetUp(i);
            newSlot.bestiario = bestiario;
            SlotInfo newSlotInfo = newSlot.slotInfo;
            slotInfoListBestiario.Add(newSlotInfo);
            buttonSlot.interactable = false;
        }

        //Crear slots Acciones
        for(int i = 0; i < num_slots; i++)
        {
            
            GameObject slot = Instantiate<GameObject>(slotAccionesPrefab, acciones_panel);
            Slot newSlot = slot.GetComponent<Slot>();
            Button buttonSlot = slot.GetComponent<Button>();
            newSlot.SetUp(i);
            newSlot.acciones = acciones;
            SlotInfo newSlotInfo = newSlot.slotInfo;
            slotInfoListAcciones.Add(newSlotInfo);
            buttonSlot.interactable = false;
        }

        AddEntradaBestiario(0);
        if(PlayerPrefs.GetInt("registro_Trenti",0)==1)
            AddEntradaBestiario(1);
        if(PlayerPrefs.GetInt("registro_Musgosu",0)==1)
            AddEntradaBestiario(2);
        if(PlayerPrefs.GetInt("registro_Cuelebre",0)==1)
            AddEntradaBestiario(3);
        if(PlayerPrefs.GetInt("registro_Tarasca",0)==1)
            AddEntradaBestiario(4);

        AddEntradaAccion(0);
        AddEntradaAccion(1);
        AddEntradaAccion(3);
        if(PlayerPrefs.GetInt("registro_PonerCebo",0)==1)
            AddEntradaAccion(2);
        if(PlayerPrefs.GetInt("registro_Cruz",0)==1)
            AddEntradaAccion(4);  
    }

    //Busca si ya hay un slot con la información de la bestia del id que se le pasa
    private SlotInfo FindSlotOcupadoBestiario(int idEntrada)
    {
        //Si hay un slot con la información de la bestia devuelve ese slot
        foreach(SlotInfo slotInfo in slotInfoListBestiario)
        {
            if(slotInfo.id == idEntrada && !slotInfo.isEmpty)
            {
                return slotInfo;
            }
        }

        int contador = 0;
        //Si no lo hay devuelve el primer slot vacio
        foreach(SlotInfo slotInfo in slotInfoListBestiario)
        {
            if(slotInfo.isEmpty)
            {
                PosSlotLlenar = contador;
                slotInfo.EmptySlot();
                return slotInfo;
            }
            contador++;
        }

        //Si no hay slot disponibles no devuelve nada
        return null;
    }
    
    //Busca si ya hay un slot con la información de la accion del ide que se le pasa
    private SlotInfo FindSlotOcupadoAccion(int idEntrada)
    {
        //Si hay un slot con la información de la bestia devuelve ese slot
        foreach(SlotInfo slotInfo in slotInfoListAcciones)
        {
            if(slotInfo.id == idEntrada && !slotInfo.isEmpty)
            {
                return slotInfo;
            }
        }

        int contador = 0;
        //Si no lo hay devuelve el primer slot vacio
        foreach(SlotInfo slotInfo in slotInfoListAcciones)
        {
            if(slotInfo.isEmpty)
            {
                PosSlotLlenar = contador;
                slotInfo.EmptySlot();
                return slotInfo;
            }
            contador++;
        }

        //Si no hay slot disponibles no devuelve nada
        return null;
    }
    
    //Saca el Slot del menú desplegable del bestiario asociado a la posición PosSlotLlenar
    private Slot FindSlotBestiario()
    {
        return bestiario_panel.GetChild(PosSlotLlenar).GetComponent<Slot>();      
    }
    
    //Saca el Slot del menú desplegable del listado de acciones asociado a la posición PosSlotLlenar
    private Slot FindSlotAcciones()
    {
        return acciones_panel.GetChild(PosSlotLlenar).GetComponent<Slot>();
    }
    
    //Añade una entrada al bestiario asociándole un determinado id
    public void AddEntradaBestiario(int IdEntrada)
    {
        Entrada_Bestia bestia = bestiario.FindEntrada_Bestia(IdEntrada);
        if(bestia != null)
        {
            SlotInfo slotInfo = FindSlotOcupadoBestiario(IdEntrada);
            if(slotInfo != null)
            {
                
                //Si el slot está vacio, lo rellenamos con la entrada y alertamos de que se a añadido una nueva entrada al bestiario
                if(slotInfo.isEmpty)
                {
                    slotInfo.id = IdEntrada;
                    slotInfo.isEmpty = false;

                    FindSlotBestiario().UpdateUI();
                    GameObject ad = Instantiate(Advertencia,new Vector3(0,0,0), Quaternion.identity);
                    ad.GetComponent<MensajeAnalisis>().BestiarioActualizado();
                }
                //Si la bestia ya tiene una entrada en el bestiario, alertar de que ya existe una entrada
                else{
                    if(!GameObject.FindGameObjectWithTag("Advertencia"))
                    {
                        GameObject ad = Instantiate(Advertencia,new Vector3(0,0,0), Quaternion.identity);
                        ad.GetComponent<MensajeAnalisis>().EntradaExistente();
                    }
                }
            }
        }
    }
    
    //Añade una entrada al listado de acciones asociándole un determinado id
    public void AddEntradaAccion(int IdEntrada)
    {
        Accion accion = acciones.FindAcciones(IdEntrada);
        if(accion != null)
        {
            SlotInfo slotInfo = FindSlotOcupadoAccion(IdEntrada);
            if(slotInfo != null)
            {
                //Si el slot está vacio, lo rellenamos con la entrada y alertamos de que se a añadido una nueva entrada al bestiario
                if(slotInfo.isEmpty)
                {
                    slotInfo.id = IdEntrada;
                    slotInfo.isEmpty = false;

                    FindSlotAcciones().UpdateUI();

                }
            }
        }
    }
}
