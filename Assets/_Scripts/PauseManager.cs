using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;
    public SceneChanger sC;

    private void Start()
    {
        pausePanel.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown("escape") && !GameManager.Instance.isPause && !GameManager.Instance.isGameFinish)
        {
            Pause();
        }
        else if (Input.GetKeyDown("escape") && GameManager.Instance.isPause && !GameManager.Instance.isGameFinish)
        {
            Unpause();
        }
    }

    public void Pause()
    {
        SoundManager.Instance.PlaySFX("Click");
        GameManager.Instance.isPause = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Unpause()
    {
        SoundManager.Instance.PlaySFX("Click");
        GameManager.Instance.isPause = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void ResetGame()
    {
        GameManager.Instance.ResetGame();
        GameManager.Instance.isPause = false;
        sC.ChangeScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    } 
    public void MainMenu()
    {
        GameManager.Instance.isPause = false;
        sC.ChangeScene(0);
    }

}
