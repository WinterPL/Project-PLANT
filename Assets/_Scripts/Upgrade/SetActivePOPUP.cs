using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivePOPUP : MonoBehaviour
{

    public GameObject panel;


    private void Start()
    {
        ClosePanel();
    }
    public void OpenPanel()
    {
        panel.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        panel.gameObject.SetActive(false);
    }



}
