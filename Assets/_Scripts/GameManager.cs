using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField] public GUN gun;
    [SerializeField] public HP hp;
    [SerializeField] public int day = 1;
    [SerializeField] public int highestDay = 1;
    [SerializeField] public int gold;
    [SerializeField] public int eneLeft = 1;
    [SerializeField] public bool GODMODE = false;
    [SerializeField] public bool pause = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        gold = 0;
        if (GODMODE)
        {
            gold = 99999999;
        }
    }

    public static GameManager Instance { get { return instance; } }

    private void Update()
    {
        //WIN
        if(eneLeft <= 0)
        {
            DayComplete();
        }
        //LOSE
        if(hp.currHP <= 0)
        {
            DayFail();
        }

    }

    private void DayComplete()
    {
        int enemies = day * 2;
        for(int i = enemies; i > 0; i--)
        {
            gold += Random.Range(50,100);
        }
        day++;
        eneLeft = 1;
        if(day > highestDay)
        {
            highestDay = day;
        }
        SceneManager.LoadScene(0);
    }

    public void DayFail()
    {
        hp.HPReset();
        gun.GUNReset();
        gold = 0;
        day = 1;
        eneLeft = 1;
        SceneManager.LoadScene(0);
    }


}
