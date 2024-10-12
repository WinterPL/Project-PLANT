using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLose_Manager : MonoBehaviour
{
    public GameObject dayFailPanel;
    public GameObject dayCompletePanel;
    public TMP_Text goldText;
    public TMP_Text tipsText;
    public string[] tips;

    private void Start()
    {
        dayCompletePanel.SetActive(false);
        dayFailPanel.SetActive(false);
    }
    private void Update()
    {
        //WIN
        if (GameManager.Instance.eneLeft <= 0)
        {
            Time.timeScale = 0;
            GameManager.Instance.isGameFinish = true;
            Win();
        }
        //LOSE
        if (GameManager.Instance.hp.currHP <= 0)
        {
            Time.timeScale = 0;
            GameManager.Instance.isGameFinish = true;
            Lose();
        }
    }
    public void Win()
    {
        dayCompletePanel.SetActive(true);
        GameManager.Instance.eneLeft = 1;
        int randomTipsIndex = Random.Range(0, tips.Length);
        tipsText.text = tips[randomTipsIndex];

        int enemies = (GameManager.Instance.day+1) * 2;
        int getGold = 0;
        for (int i = enemies; i > 0; i--)
        {
            getGold += Random.Range(50, 100);
        }

        goldText.text = GameManager.Instance.gold + " + " + getGold;

        GameManager.Instance.day++;
        if (GameManager.Instance.day > GameManager.Instance.highestDay)
        {
            GameManager.Instance.highestDay = GameManager.Instance.day;
        }
        GameManager.Instance.gold += getGold;
    }

    public void Lose()
    {
        dayFailPanel.SetActive(true);
        GameManager.Instance.ResetGame();
    }

}
