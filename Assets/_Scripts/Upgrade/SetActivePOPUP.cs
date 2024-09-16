using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivePOPUP : MonoBehaviour
{

    public GameObject panel;

    private void Start()
    {
        panel.gameObject.SetActive(false);
    }
    public void OpenPanel()
    {
        SoundManager.Instance.PlaySFX("Click");
        panel.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        SoundManager.Instance.PlaySFX("Click");
        panel.gameObject.SetActive(false);
    }



}
