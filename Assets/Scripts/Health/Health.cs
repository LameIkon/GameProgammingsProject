using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{

    public int healthPoint { get; private set;  }
    public int maxHealthPoints { get; private set; }


    public Health(int healthPoint, int maxHealthPoints)
    {
        this.healthPoint = healthPoint;
        this.maxHealthPoints = maxHealthPoints;
    }
}
