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

    public void UpdateUI()
    {
        //SLOTS


    }
}
