using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void ChangeScene(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
        Time.timeScale = 1;
    }
}
