using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public int classID;   //0=enemy, 1=warrior
    //survival stats
    public float health;
    public float regen;
    //stamina stats
    public float energy;
    public float speed;
    //combat stats
    public float power;      
    public float aim;

    // Start is called before the first frame update
    public void Warrior(float level)
    {
        health = 100 + (level * 10);
        regen = 5 + (level * 0.5f);
        energy = 10 + (level);
        speed = 5 + (level * 0.2f);
        power = 5 + (level * 0.5f);
        aim = 50 + (level * 2);
    }
}
