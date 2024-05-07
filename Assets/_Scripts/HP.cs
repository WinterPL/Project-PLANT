using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int currHP = 100;
    public int barricadeLV = 1;
    void Start()
    {
        //desirelize
    }
    public void UpgradeBarricade()
    {
        barricadeLV++;
        currHP = barricadeLV * 100;
    }
    public void Reset()
    {
        currHP = barricadeLV * 100;
    }

    public void GotHit(int dmg)
    {
        currHP -= dmg;
    }

}
