using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] public GUN gun;
    [SerializeField] public HP hp;
    [SerializeField] public int day = 0;
    [SerializeField] public int highestDay = 0;
    [SerializeField] public int gold;
    [SerializeField] public int eneLeft = 1;
    [SerializeField] public bool isPause = false;
    [SerializeField] public bool isGameFinish = false;

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

    private void Update()
    {
        //NONE
    }


    public void ResetGame()
    {
        hp.HPReset();
        gun.GUNReset();
        gold = 0;
        day = 0;
        eneLeft = 1;
    }
    public void AngelGift()
    {
        gold += 99999999;
        hp.currHP += 100000;
    }


}
