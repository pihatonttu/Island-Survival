using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Uusi esine", menuName = "Reppu/Esine")]
public class Item : ScriptableObject
{

    new public string nimi = "New Item";    //Esineen nimi
    public Sprite kuvake = null;    //Esineen pikkukuvake
    public bool NaytaRepussa = true;    //Näytetäänkö esine repussa

    //Kutsutaan kun esinettä painetaan repussa
    public virtual void Kayta()
    {
        //Mitä tehdään
    }

    //Poistetaan esine repusta
    public void PoistaRepusta()
    {
        Inventory.instance.Poista(this);
    }

}
