using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;  //Koko ui
    public Transform itemsParent;   //Esineiden isukki

    Inventory inventory;    //Nykyinen reppu


    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
    }


    void Update()
    {
        //Tarkistetaan jos nappia painetaan niin avataan/suljetaan reppu
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            UpdateUI();
        }
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
}
