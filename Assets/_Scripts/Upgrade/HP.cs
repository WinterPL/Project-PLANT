using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    [SerializeField] public int currHP = 100;
    [SerializeField] public int barricadeLV = 1;

    [SerializeField] public GameObject[] barricade;
    [SerializeField] public SpriteRenderer[] barricadeIMG;

    [SerializeField] Color getHit;
    [SerializeField] Color backHit;
    public float gethitCD;

    [SerializeField] private AudioSource bdmgAudio;
    void Start()
    {
        barricade[0].gameObject.SetActive(false);
        barricade[1].gameObject.SetActive(false);
        barricade[2].gameObject.SetActive(false);
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "DeploymentScene")
        {
            float HPpercent = (currHP / (barricadeLV * 100.0f)) * 100.0f;
            if (HPpercent >= 50.0f)
            {
                //Debug.Log(HPpercent);
                barricade[0].gameObject.SetActive(true);
                barricade[1].gameObject.SetActive(false);
                barricade[2].gameObject.SetActive(false);
            }
            else if (HPpercent < 50.0f && HPpercent > 20.0f)
            {
                //Debug.Log(HPpercent);
                barricade[0].gameObject.SetActive(false);
                barricade[1].gameObject.SetActive(true);
                barricade[2].gameObject.SetActive(false);
            }
            else if (HPpercent <= 20.0f)
            {
                //Debug.Log(HPpercent);
                barricade[0].gameObject.SetActive(false);
                barricade[1].gameObject.SetActive(false);
                barricade[2].gameObject.SetActive(true);
            }
        }
        else
        {
            barricade[0].gameObject.SetActive(false);
            barricade[1].gameObject.SetActive(false);
            barricade[2].gameObject.SetActive(false);
        }

        if (gethitCD > 0.0f)
        {
            foreach (SpriteRenderer i in barricadeIMG)
            {
                i.color = getHit;
            }
            gethitCD -= Time.deltaTime;
            if (gethitCD <= 0.0f)
            {
                foreach (SpriteRenderer i in barricadeIMG)
                {
                    i.color = backHit;
                }
            }
        }

    }

    public string UpgradeBarricade()
    {
        if(GameManager.Instance.gold >= (barricadeLV*1000) )
        {
            GameManager.Instance.gold -= (barricadeLV * 1000);
            barricadeLV++;
            currHP = barricadeLV * 100;
            return "Barricade Upgrade to Level " + barricadeLV;
        }
        else
        {
            return "Insufficient Gold" ;
        }
    }
    public string FixBarricade(int num)
    {
        if(currHP == (barricadeLV * 100))
        {
            return "Barricade is in Full health";
        }

        switch(num)
        {
            case 1:
                if(GameManager.Instance.gold >= (barricadeLV*50))
                { 
                    currHP += (barricadeLV * 100) / 2;
                    checkFullHealth();
                    GameManager.Instance.gold -= (barricadeLV * 50);
                    return "Barricade is Fix in Half capacity";
                }
                else
                {
                    return "Insufficient Gold";
                }
            case 2:
                if (GameManager.Instance.gold >= (barricadeLV * 90))
                {
                    currHP += barricadeLV * 100;
                    checkFullHealth();
                    GameManager.Instance.gold -= (barricadeLV * 90);
                    return "Barricade is Fix in Full capacity";
                }
                else
                {
                    return "Insufficient Gold";
                }
            default:
                return "Something is wrong";
        }
    }

    private void checkFullHealth()
    {
        if (currHP > (barricadeLV * 100))
        {
            currHP = barricadeLV * 100;
        }
    }

    public void GotHit(int dmg)
    {
        bdmgAudio.Play();
        currHP -= dmg;
        gethitCD = 0.2f;
    }

    public void HPReset()
    {
        currHP = 100;
        barricadeLV = 1;
    }
}
