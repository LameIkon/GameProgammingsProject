using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Weapon/Grenade")]
public class Grenade : Weapon
{
    [SerializeField] private float radius;
    [SerializeField] private float fuseTime;

    [Header("Explode on Impact")]
    [SerializeField] private bool impactExplotion;



    public override int DoDamage()
    {
        return GetDamage();
    }

  
    public bool ExplodesOnImpact() { return impactExplotion; }

    public float GetRadius(){ return radius; }

    public float GetFuse() { return fuseTime; }
}
