using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public Image tausta;
    public Image kuvake;
    public Text MaaraTeksti;

    public Item esine; //nykyinen esine tässä paikassa
    int maara; //Montako samaa esinettä tässä paikassa on

    //Lisää esine
    public void LisaaEsine(Item uusiEsine)
    {
        //Lisätään uusi esine
        esine = uusiEsine;

        //Näytetään esineen kuvake
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
    
    //Näytä määrä
    public void PinoaEsine(int montako)
    {
        maara = montako;
        MaaraTeksti.text = maara.ToString();
    }

    public void Valittu()
    {
        tausta.color = new Color(125, 125, 0,25);
    }
    public void PoistaValinta()
    {
        tausta.color = new Color(255,255,255,25);
    }
}
