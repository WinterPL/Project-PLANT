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
    // Start is called before the first frame update
    void Start()
    {
        if(isGold)
        {
        Text.text = GameManager.instance.gold.ToString();
        }
        else if (isENEleft)
        {
            Text.text = "Enemy left : " + GameManager.Instance.eneLeft.ToString();
        }
        else if(isDay)
        {
            Text.text = "DAY : " + GameManager.Instance.day.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGold)
        {
            Text.text = GameManager.instance.gold.ToString();
        }
        else if (isENEleft)
        {
            Text.text = "Enemy left : " + GameManager.Instance.eneLeft.ToString();
        }
        else if (isDay)
        {
            Text.text = "DAY : " + GameManager.Instance.day.ToString();
        }
    }
}
