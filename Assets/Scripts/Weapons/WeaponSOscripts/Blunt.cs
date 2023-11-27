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
        if (IsWeaponBroken()) return 0;
        LooseDurability(1);
        return 2 * base.GetWeight() + base.GetDamage();
    }

}
