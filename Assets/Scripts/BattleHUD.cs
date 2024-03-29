using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI  nameText;
    public TextMeshProUGUI  levelText;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lv : " + unit.unitLevel;
        //hpSlider.maxValue = unit.maxHP;
        //hpSlider.value = unit.currentHp;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
