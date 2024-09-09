using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown("escape") && GameManager.Instance.pause == false)
        {
            Pause();
        }
        else if (Input.GetKeyDown("escape") && GameManager.Instance.pause == true)
        {
            Unpause();
        }
    }

    public void Pause()
    {
        GameManager.Instance.pause = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Unpause()
    {
        GameManager.Instance.pause = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void ResetGame()
    {
        GameManager.Instance.DayFail();
        GameManager.Instance.pause = false;
    }

    public void Exit()
    {
        Application.Quit();
    } 
    public void MainMenu()
    {
        //CHEATs
        SceneManager.LoadScene(0);
    }

}
