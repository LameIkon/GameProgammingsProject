using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Blunt")]
public class Blunt : Melee
{
    /*
    public Blunt(int damage, string name, int weight) : base(damage, name, weight)
    {

    }
     */

    public override int DoDamage()
    {
        LooseDurability(1);
        return base.GetWeight() + base.GetDamage() + base.GetDurability();
    }

}
