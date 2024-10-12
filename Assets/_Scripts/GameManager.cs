using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] public GUN gun;
    [SerializeField] public HP hp;
    [SerializeField] public int day = 1;
    [SerializeField] public int highestDay = 1;
    [SerializeField] public int gold;
    [SerializeField] public int eneLeft = 1;
    [SerializeField] public bool pause = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
    }

    //public static GameManager Instance { get { return instance; } }

    private void Update()
    {
        //WIN
        if (eneLeft <= 0)
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
        day++;
        eneLeft = 1;
        if(day > highestDay)
        {
            highestDay = day;
        }
        WinLose_Manager.Win();
    }

    public void DayFail()
    {
        hp.HPReset();
        gun.GUNReset();
        gold = 0;
        day = 1;
        eneLeft = 1;
        WinLose_Manager.Lose();
    }

    public void AngelGift()
    {
        gold += 99999999;
        hp.currHP += 100000;
    }


}
