using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{

    [SerializeField] private int damage;
    [SerializeField] private new string name;
    [SerializeField] private int weight;
    [Range(0, 100)]
    [SerializeField] private int durability;

    /*
    public Weapon(int damage, string name, int weight) 
    {
        this.damage = damage;
        this.name = name;
        this.weight = weight;
    }
     */

    public abstract int DoDamage();

    public virtual void LooseDurability(int damage)
    {
        if (IsWeaponBroken()) return;
        this.durability -= damage;
    }

    public string GetName() { return name; }

    public int GetDamage() { return damage; }
    
    public int GetWeight() { return weight; }

    public int GetDurability(){ return durability; }

    protected bool IsWeaponBroken() {
        
        if(GetDurability() < 0) return true;

        else
            return false;
    
    }

}

