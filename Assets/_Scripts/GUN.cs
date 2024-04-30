using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN : MonoBehaviour
{
    [SerializeField] public int bDamage = 1;
    [SerializeField] public float bRateofFire = 1.0f;
    [SerializeField] public float bSpeed = 10.0f;
    [SerializeField] public int bPeiceing = 0;

    void Start()
    {
        //desirelize
    }

    public void UpgradeDMG()
    {
        bDamage += 1;
    }
    public void UpgradeROF()
    {
        bRateofFire += 1.0f;
    }
    public void UpgradeSPD()
    {
        bSpeed += 1.0f;
    }
    public void UpgradeP()
    {
        bPeiceing += 1;
    }
}
