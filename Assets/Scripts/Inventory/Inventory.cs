using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    //Delegoidaan tehtäviä
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    //Montako esinettä reppuun mahtuu
    public int koko = 9;

    //Nykyinen lista repun esineistä
    public List<Item> esineet = new List<Item>();

    //Lisätään uusi esine reppuun jos tilaa
    public void Lisaa(Item esine)
    {
        if(esine.NaytaRepussa)
        {
            if (esineet.Count >= koko)
            {
                Debug.Log("Reppu on täynnä.");
                return;
            }

            esineet.Add(esine);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    //Poistetaan esine
    public void Poista(Item esine)
    {
        esineet.Remove(esine);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
