using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLose_Manager : MonoBehaviour
{
    public GameObject dayFailPanel;
    public GameObject dayComplerePanel;
    public TMP_Text MoneyText;
    public static void Win()
    {
        int enemies = GameManager.Instance.day * 2;
        int getGold = 0;
        for (int i = enemies; i > 0; i--)
        {
            getGold += Random.Range(50, 100);
        }
    }

    public static void Lose()
    {

    }

}
