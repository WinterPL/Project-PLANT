using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Vector3 mousePos;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float force;
    [SerializeField] public int peicing;

    [SerializeField] private float cooldown = 7.0f;

    void Start()
    {
        force = GameManager.Instance.gun.bSpeed;
        peicing = GameManager.Instance.gun.bPeiceing;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if(peicing<0|| cooldown <= 0)
        {
            Destroy(this.gameObject);
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Hit");
            peicing--;
        }
    }
}
