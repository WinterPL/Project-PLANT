using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivePOPUP : MonoBehaviour
{

    public GameObject panel;

    [SerializeField] private AudioSource clickAudio;


    private void Start()
    {
        panel.gameObject.SetActive(false);
    }
    public void OpenPanel()
    {
        clickAudio.Play();
        panel.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        clickAudio.Play();
        panel.gameObject.SetActive(false);
    }



}
