using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int unitATK;
    public int unitDEF;
    public int unitMG;

    public float[] offMagic;
    public float defMagic;

    public int maxHP;
    public int currentHp;

    private float minMax;

    public bool TakeDamage(int damage)
    {
        currentHp -= damage;
        //Check Death
        if(currentHp <= 0)
            return true;
        else
            return false;
    }


}
