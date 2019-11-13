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
    public List<int> esineidenMaarat = new List<int>();

    //Lisätään uusi esine reppuun jos tilaa
    public bool Lisaa(Item esine)
    {
        //Jos esineellä on NaytaRepussa boolean niin etsitään sille paikka
        if(esine.NaytaRepussa)
        {
            //Tarkastetaan että repuss ei ole jo samaa esinettä
            int OnkoSama = HaeIndex(esine);    //Jos index on -1 listassa ei ole samaa mutta jos se on jotain muuta niin on
            if (OnkoSama >= 0)
            {
                esineidenMaarat[OnkoSama] += 1;
            }
            else
            {
                esineet.Add(esine);
                esineidenMaarat.Add(1);
            }

            //Jos reppu on täynnnä perutaan lisäys
            if (esineet.Count >= koko)
            {
                Debug.Log("Reppu on täynnä.");
                return false;
            }

            //Lähetään tieto että reppu on muuttunut
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    //Poistetaan esine
    public void Poista(Item esine)
    {
        esineet.Remove(esine);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    int HaeIndex(Item esine)
    {
        for (int i = 0; i < esineet.Count; i++)
        {
            if (esine == esineet[i])
                return i;
        }
        return -1;
    }
}
