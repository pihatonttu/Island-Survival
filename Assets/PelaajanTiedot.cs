using UnityEngine;

public class PelaajanTiedot : MonoBehaviour
{
    #region Singleton
    public static PelaajanTiedot instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    int _maksimiElama = 100;    //pelaajan maksimi elämä
    int _nykyinenElama;         //Pelaajan tämän hetkinen elämä

    //Annetaan pelaajalle täyde elämät kun peli alkaa
    public void Start()
    {
        _nykyinenElama = _maksimiElama;
    }

    //Kutsutaan tätä kun pelaaja ottaa osumaa
    public void OtaOsumaa(int maara)
    {
        _nykyinenElama -= maara;
        Debug.Log("Pelaaja otti " + maara + " osumaa!");

        if(_nykyinenElama <= 0)
        {
            //Pelaaja kuolee
        }
    }

    //Kutsutaan tätä kun pelaajalle annetaan lisää hp:ta
    public void Paranna(int maara)
    {
        _nykyinenElama += maara;
        _nykyinenElama = Mathf.Clamp(_nykyinenElama, 0, _maksimiElama);
    }
}
