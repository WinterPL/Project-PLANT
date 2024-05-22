using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WEAPON_UPGRADER : MonoBehaviour
{
    public TMP_Text RofFLevel_Text;
    public TMP_Text RofFLevel_Text_Price;

    public TMP_Text bDamage_Text;
    public TMP_Text bDamage_Text_Price;
    public TMP_Text bSpeed_Text;
    public TMP_Text bSpeed_Text_Price;
    public TMP_Text bPeicing_Text;
    public TMP_Text bPeicing_Text_Price;

    public TMP_Text Debug_TEXT;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gun.gRateOfFireLV == 10)
        {
            RofFLevel_Text.text = "Weapon Level : MAX";
            RofFLevel_Text_Price.text = " ";
        }
        else
        {
        RofFLevel_Text.text = "Weapon Level : " + GameManager.Instance.gun.gRateOfFireLV.ToString();
        RofFLevel_Text_Price.text = (GameManager.Instance.gun.gRateOfFireLV * 500).ToString();
        }

        bDamage_Text.text = "DAMAGE : " + GameManager.Instance.gun.bDamage.ToString();
        bDamage_Text_Price.text = (GameManager.Instance.gun.bDamageLV * 150).ToString();
        bSpeed_Text.text = "BULLET SPEED : " + GameManager.Instance.gun.bSpeed.ToString();
        bSpeed_Text_Price.text = (GameManager.Instance.gun.bSpeedLV * 150).ToString();
        bPeicing_Text.text = "BULLET PEICING : " + GameManager.Instance.gun.bPeiceing.ToString();
        bPeicing_Text_Price.text = (GameManager.Instance.gun.bPeiceingLV * 150).ToString();
    }

    public void UpRofFire()
    {
        Debug_TEXT.text = GameManager.Instance.gun.UpgradeROF().ToString();
    }

    public void UpDMG()
    {
        Debug_TEXT.text = GameManager.Instance.gun.UpgradeDMG().ToString();
    }
    public void UpSPD()
    {
        Debug_TEXT.text = GameManager.Instance.gun.UpgradeSPD().ToString();
    }
    public void UpP()
    {
        Debug_TEXT.text = GameManager.Instance.gun.UpgradeP().ToString();
    }



}
