using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;  //Koko ui
    public Transform itemsParent;   //Esineiden isukki

    Inventory inventory;    //Nykyinen reppu

    public int ValittuPaikka = 0;   //Nykyinen valinta repussa


    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            VarjaaPaikat();
            VaihdaValinta(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            VarjaaPaikat();
            VaihdaValinta(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            VarjaaPaikat();
            VaihdaValinta(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            VarjaaPaikat();
            VaihdaValinta(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            VarjaaPaikat();
            VaihdaValinta(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            VarjaaPaikat();
            VaihdaValinta(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            VarjaaPaikat();
            VaihdaValinta(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            VarjaaPaikat();
            VaihdaValinta(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            VarjaaPaikat();
            VaihdaValinta(8);
        }
        //Tarkistetaan jos nappia painetaan niin avataan/suljetaan reppu
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            UpdateUI();
        }
    }

    public void VaihdaValinta(int mika)
    {
        InventorySlots[] paikat = GetComponentsInChildren<InventorySlots>();

        paikat[mika].Valittu();
    }

    //Päivitä Repun UI
    public void UpdateUI()
    {
        //Etsitään paikat
        InventorySlots[] paikat = GetComponentsInChildren<InventorySlots>();


        //Käydään läpi kaikki paikat
        for (int i = 0; i < paikat.Length; i++)
        {
            if (i < inventory.esineet.Count)
            {
                paikat[i].LisaaEsine(inventory.esineet[i]);
                if(inventory.esineidenMaarat[i] > 1)
                {
                    paikat[i].PinoaEsine(inventory.esineidenMaarat[i]);
                }
            }
            else
            {
                paikat[i].PoistaSlot();
            }
        }
       
    }
    public void VarjaaPaikat()
    {
        InventorySlots[] paikat = GetComponentsInChildren<InventorySlots>();
        for (int i = 0; i < paikat.Length; i++)
        {
            paikat[i].PoistaValinta();
        }
    }
}
