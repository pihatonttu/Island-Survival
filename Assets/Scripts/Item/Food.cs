using UnityEngine;

[CreateAssetMenu(fileName = "Uusi ruoka",menuName = "Reppu/Ruoka")]
public class Food : Item
{
    //Paljonko palauttaa hp:ta
    public int HpMaara;

    public override void Kayta()
    {
        base.Kayta();

        PelaajanTiedot.instance.Paranna(HpMaara);
        //Anna pelaajalle elämää

    }
}
