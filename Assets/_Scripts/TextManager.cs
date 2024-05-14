using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextManager : MonoBehaviour
{
    public TMP_Text Text;
    public bool isGold = true;
    // Start is called before the first frame update
    void Start()
    {
        if(isGold)
        {
        Text.text = GameManager.instance.gold.ToString();
        }
        else
        {
            Text.text = GameManager.Instance.eneLeft.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGold)
        {
            Text.text = GameManager.instance.gold.ToString();
        }
        else
        {
            Text.text = "Enemy left : " + GameManager.Instance.eneLeft.ToString();
        }
    }
}
