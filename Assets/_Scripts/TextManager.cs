using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextManager : MonoBehaviour
{
    [SerializeField] public TMP_Text Text;
    [SerializeField] public bool isGold = false;
    [SerializeField] public bool isENEleft = false;
    [SerializeField] public bool isDay = false;
    [SerializeField] public bool isHighestDay = false;
    // Start is called before the first frame update
    void Start()
    {
        Text.gameObject.SetActive(true);

        if (isGold)
        {
        Text.text = GameManager.Instance.gold.ToString();
        }
        else if (isENEleft)
        {
            Text.text = "Enemy left : " + GameManager.Instance.eneLeft.ToString();
        }
        else if(isDay)
        {
            Text.text = "DAY : " + GameManager.Instance.day.ToString();
        }
        else if (isHighestDay)
        {
            Text.text = "Highest DAY : " + GameManager.Instance.highestDay.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameFinish)
        {
            Text.gameObject.SetActive(false);
        }

        if (isGold)
        {
            Text.text = GameManager.Instance.gold.ToString();
        }
        else if (isENEleft)
        {
            Text.text = "Enemy left : " + GameManager.Instance.eneLeft.ToString();
        }
        else if (isDay)
        {
            Text.text = "DAY : " + GameManager.Instance.day.ToString();
        }
        else if (isHighestDay)
        {
            Text.text = "Highest DAY : " + GameManager.Instance.highestDay.ToString();
        }
    }
}
