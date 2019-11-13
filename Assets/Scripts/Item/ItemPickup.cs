using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item esine;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    //Nosta esine
    void PickUp()
    {
        Debug.Log("Otetaan " + esine.nimi);

        //Jos lisäys menee läpi niin poistetaan esine
        if(Inventory.instance.Lisaa(esine))
            Destroy(gameObject);
    }
}
