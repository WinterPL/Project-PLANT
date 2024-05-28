using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BUILDING_UPGRADER : MonoBehaviour
{
    [SerializeField] public TMP_Text Level_Text;
    [SerializeField] public TMP_Text HP_TEXT;
    [SerializeField] public TMP_Text UpgradePRICE_TEXT;
    [SerializeField] public TMP_Text RepairHPRICE_TEXT;
    [SerializeField] public TMP_Text RepairFPRICE_TEXT;
    [SerializeField] public TMP_Text Debug_TEXT;

    void Update()
    {
        Level_Text.text = ("LEVEL : " + GameManager.Instance.hp.barricadeLV).ToString();
        HP_TEXT.text = "Barricade Health      " + (GameManager.Instance.hp.currHP + " / " + (GameManager.Instance.hp.barricadeLV * 100)).ToString();
        UpgradePRICE_TEXT.text = (GameManager.Instance.hp.barricadeLV * 1000).ToString();
        RepairHPRICE_TEXT.text = (GameManager.Instance.hp.barricadeLV * 50).ToString();
        RepairFPRICE_TEXT.text = (GameManager.Instance.hp.barricadeLV * 90).ToString();
    }

    public void UpgradeBarricade()
    {
        Debug_TEXT.text = GameManager.Instance.hp.UpgradeBarricade();
    }

    public void FixBarricade(int FixLevel)
    {
        Debug_TEXT.text = GameManager.Instance.hp.FixBarricade(FixLevel);
    }

}
