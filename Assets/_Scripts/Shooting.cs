using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;

    public GameObject bullet;
    public Transform bTransform;
    public float timer;
    public bool canShoot = true;
    public float RateOfF = 0.0f;

    void Start()
    {
        RateOfF = GameManager.Instance.gun.bRateofFire;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);

        if(!canShoot)
        {
            timer += Time.deltaTime;
            if(timer > RateOfF)
            {
                canShoot = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canShoot)
        {
            Debug.Log("Shoot");
            canShoot = false;
            Instantiate(bullet,bTransform.position,Quaternion.identity);
        }

    }
}
