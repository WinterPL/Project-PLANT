using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BUILDING_UPGRADER : MonoBehaviour
{
    [SerializeField] public TMP_Text level_Text;
    [SerializeField] public TMP_Text upgradePRICE_TEXT;
    [SerializeField] public TMP_Text hP_TEXT;
    [SerializeField] public TMP_Text repairHPRICE_TEXT;
    [SerializeField] public TMP_Text repairFPRICE_TEXT;
    [SerializeField] public TMP_Text debug_TEXT;

    //[SerializeField] private AudioSource clickAudio;
    void Update()
    {
        level_Text.text = ("LEVEL : " + GameManager.Instance.hp.barricadeLV).ToString();
        hP_TEXT.text = "Barricade Health      " + (GameManager.Instance.hp.currHP + " / " + (GameManager.Instance.hp.barricadeLV * 100)).ToString();
        upgradePRICE_TEXT.text = (GameManager.Instance.hp.barricadeLV * 1000).ToString();
        repairHPRICE_TEXT.text = (GameManager.Instance.hp.barricadeLV * 50).ToString();
        repairFPRICE_TEXT.text = (GameManager.Instance.hp.barricadeLV * 90).ToString();
    }

    public void UpgradeBarricade()
    {
        SoundManager.Instance.PlaySFX("Click");
        debug_TEXT.text = GameManager.Instance.hp.UpgradeBarricade();
    }

    public void FixBarricade(int FixLevel)
    {
        SoundManager.Instance.PlaySFX("Click");
        debug_TEXT.text = GameManager.Instance.hp.FixBarricade(FixLevel);
    }

}
