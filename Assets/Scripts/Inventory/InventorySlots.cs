using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{

    public Image kuvake;
    public Text MaaraTeksti;

    Item esine; //nykyinen esine tässtä slotissa

    //Lisää esine
    public void LisaaEsine(Item uusiEsine)
    {
        esine = uusiEsine;

        kuvake.sprite = esine.kuvake;
        kuvake.enabled = true;
    }

    //Puhdista slotti
    public void PoistaSlot()
    {
        esine = null;

        kuvake.sprite = null;
        kuvake.enabled = false;
    }

    //Poistetaan esine repusta jos nappia painetaan
    public void PoistaEsineRepusta()
    {
        Inventory.instance.Poista(esine);
    }

    //Käytä esinettä
    public void KaytaEsine()
    {
        if (esine != null)
        {
            esine.Kayta();
        }
    }
}
