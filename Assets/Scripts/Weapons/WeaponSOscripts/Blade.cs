using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Weapon/Blade")]
public class Blade : Melee
{

    [Range(0, 20f)]
    [SerializeField] private float sharpness;
    /*
    public Blade(int damage, string name, int weight, float sharpness) : base(damage, name, weight) { 
        this.sharpness = sharpness;
    }
     */


    public override int DoDamage()
    {
        if (IsWeaponBroken()) return 0;
        LooseDurability(1);
        return base.GetDamage() + (int)(sharpness / base.GetWeight());
    }

    public override void LooseDurability(int damage)
    {
        base.LooseDurability(damage);
        LooseSharpness(damage / 8f);
    }

    public void LooseSharpness(float dulling) 
    {
        this.sharpness -= dulling;
    }

}