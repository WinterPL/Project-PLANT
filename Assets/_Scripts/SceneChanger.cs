using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int SceneNum)
    {
        GameManager.Instance.isGameFinish = false;
        SceneManager.LoadScene(SceneNum);
        Time.timeScale = 1;
    }
}
