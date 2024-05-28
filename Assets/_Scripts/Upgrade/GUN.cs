using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN : MonoBehaviour
{
    [SerializeField] public int gRateOfFireLV = 1;
    [SerializeField] public float gRateofFire = 1.0f;

    [SerializeField] public int bDamageLV = 1;
    [SerializeField] public int bDamage = 1;
    [SerializeField] public int bSpeedLV = 1;
    [SerializeField] public float bSpeed = 10.0f;
    [SerializeField] public int bPeiceingLV = 1;
    [SerializeField] public int bPeiceing = 0;

    void Start()
    {
        //desirelize
    }

    public string UpgradeROF()
    {
        if (gRateOfFireLV < 10 && GameManager.Instance.gold >= (gRateOfFireLV * 500))
        {
            gRateofFire -= 0.075f;
            gRateOfFireLV++;
            GameManager.Instance.gold -= (gRateOfFireLV * 500);
            return "Weapon Upgrade to Level " + gRateOfFireLV;
        }
        else if(gRateOfFireLV == 10)
        {
            return "Weapon is already MAX LEVEL";
        }
        else
        {
            return "Insufficient Gold";
        }
    }

    public string UpgradeDMG()
    {
        if (GameManager.Instance.gold >= (bDamageLV * 150))
        {
            bDamage += 1;
            bDamageLV++;
            GameManager.Instance.gold -= (bDamageLV * 150);
            return "Bullet Damage increase to " + bDamage;
        }
        else
        {
            return "Insufficient Gold";
        }
    }

    public string UpgradeSPD()
    {
        if (GameManager.Instance.gold >= (bSpeedLV * 150))
        {
            bSpeed += 1;
            bSpeedLV++;
            GameManager.Instance.gold -= (bSpeedLV * 150);
            return "Bullet Speed increase to " + bSpeed;
        }
        else
        {
            return "Insufficient Gold";
        }
    }

    public string UpgradeP()
    {
        if (GameManager.Instance.gold >= (bPeiceingLV * 150))
        {
            bPeiceing += 1;
            bPeiceingLV++;
            GameManager.Instance.gold -= (bPeiceingLV * 150);
            return "Bullet Peicing increase to " + bPeiceing;
        }
        else
        {
            return "Insufficient Gold";
        }
    }

    public void GUNReset()
    {
        gRateOfFireLV = 1;
        gRateofFire = 1.0f;
        bDamageLV = 1;
        bDamage = 1;
        bSpeedLV = 1;
        bSpeed = 10.0f;
        bPeiceingLV = 1;
        bPeiceing = 0;
    }
}
