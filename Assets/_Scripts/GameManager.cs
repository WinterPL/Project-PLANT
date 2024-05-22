using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GUN gun;
    public HP hp;
    [SerializeField] public int day = 1;
    public int gold;
    public int eneLeft = 1;
    public bool GODMODE = false;

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

    public static GameManager Instance { get { return instance; } }

    private void Update()
    {
        if(eneLeft <= 0)
        {
            DayComplete();
        }

        if(GODMODE)
        {
            gold = 99999999;
        }
    }

    private void DayComplete()
    {
        int enemies = day * 2;
        for(int i = enemies; i > 0; i--)
        {
            gold += Random.Range(50,100);
            //Debug.Log("Get Gold");
        }
        day++;
        eneLeft = 1;
        SceneManager.LoadScene(0);
    }



}
