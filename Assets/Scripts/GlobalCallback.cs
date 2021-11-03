using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCallback : MonoBehaviour
{

    public int callField;
    public double callScore;
    public int callRemain;
    public int callKills;
    public int callLife;
    public int[] callWeaponLevel = new int[3];
    public double[] callWeaponExp = new double[3];
    public int callCurrentWeapon;

    // Update is called once per frame
    void Update()
    {
    callField = global.field;
    callScore = global.score;
    callRemain = global.remain;
    callKills = global.kills;
    callLife = global.life;
    callWeaponLevel = global.weaponlevel;
    callWeaponExp = global.weaponexp;
    callCurrentWeapon = global.currentweapon;
    }
}
