using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit
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
}
