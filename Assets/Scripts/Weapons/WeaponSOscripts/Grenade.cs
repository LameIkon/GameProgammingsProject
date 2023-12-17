using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Weapon, Throwable
{
    public override int DoDamage()
    {
        return GetDamage();
    }


    void Throwable.Throw(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }
    
}
