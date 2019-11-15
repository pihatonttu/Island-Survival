using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*TLDR
 * Tehdään tässä esineiden pohjascripti joka säilyttää tarvittavat muuttujat
 * 
 */
[CreateAssetMenu(fileName = "Uusi esine", menuName = "Reppu/Esine")]
public class Item : ScriptableObject
{
    new public string nimi = "Uusi esine";    //Esineen nimi
    public Sprite kuvake = null;    //Esineen pikkukuvake
    public bool NaytaRepussa = true;    //Näytetäänkö esine repussa
    [Range(0, 999)]
    public int maksimipino = 1;

    //Kutsutaan kun esinettä painetaan repussa
    public virtual void Kayta()
    {
        Debug.Log(nimi + " Käytetty!");
        //Määritellään ali classeissa mitä tehdään
    }

    //Poistetaan esine repusta
    public void PoistaRepusta()
    {
        Inventory.instance.Poista(this);
    }

}
