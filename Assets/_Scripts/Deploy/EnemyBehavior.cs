using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float hP = 10;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private int mxADMG = 10;
    [SerializeField] private int mnADMG = 5;
    [SerializeField] private float hitCD = 5.0f;
    [SerializeField] private bool canHit = true;
    [SerializeField] private Collider2D[] colliders;
    private float hitWait = 0.2f;

    public bool dummy = false;
    public bool needHeal = false;
    public float healCD = 7.0f;
    [SerializeField] Animator e_Animator;

    [SerializeField] SpriteRenderer renderIMG;
    [SerializeField] Color getHit;
    [SerializeField] Color backHit;
    public float gethitCD;

    [SerializeField] private AudioSource hitAudio;
    enum Behavior
    { 
        walk,
        attack
    };

    private Behavior behave;

    // Start is called before the first frame update
    void Start()
    {
        behave = Behavior.walk;
    }

    // Update is called once per frame
    void Update()
    {
        switch (behave)
        {
            case Behavior.walk:
                GetHit();

                if (!dummy)
                {
                    this.transform.Translate(Vector3.left * speed * Time.deltaTime);
                    if (hP <= 0)
                    {
                        death();
                    }
                }
                else
                {
                    if (hP < 10)
                    {
                        needHeal = true;
                    }

                    if (needHeal)
                    {
                        healCD -= Time.deltaTime;
                        if (healCD <= 0.0f)
                        {
                            needHeal = false;
                            hP = 10;
                            healCD = 7.0f;
                        }
                    }
                }
                break;
            case Behavior.attack:
                if (hP <= 0)
                {
                    death();
                }

                GetHit();

                if (canHit)
                {
                    e_Animator.SetTrigger("Attack");
                    if(hitWait > 0.0f)
                    {
                        hitWait -= Time.deltaTime;
                    }
                    else if (hitWait <= 0.0f)
                    {
                        canHit = false;
                        int ADMG = Random.Range(mxADMG, mnADMG);
                        GameManager.instance.hp.GotHit(ADMG);
                        hitWait = 0.3f;
                    }

                }
                else
                {
                    hitCD -= Time.deltaTime;
                    if (hitCD <= 0.0f)
                    {
                        canHit = true;
                        hitCD = 5.0f;
                    }
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hitAudio.Play();
            gethitCD = 0.2f;
            //Debug.Log("Bullet ENTER");
            if (colliders[0].IsTouching(other))
            {
                //Debug.Log("HEAD");
                hP -= GameManager.Instance.gun.bDamage * 2;
            }
            else if (colliders[1].IsTouching(other))
            {
                //Debug.Log("BODY");
                hP -= GameManager.Instance.gun.bDamage;
            }
            else if (colliders[2].IsTouching(other))
            {
                //Debug.Log("LEG");
                hP -= GameManager.Instance.gun.bDamage;
                if (speed > 0.5)
                {
                    speed -= 0.5f;
                }
                else
                {
                    speed = 0.1f;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Barricade"))
        {
            //Debug.Log("Barricade hit");
            behave = Behavior.attack;
        }
    }

    private void death()
    {
        Destroy(this.gameObject);
        GameManager.instance.eneLeft--;
    }

    private void GetHit()
    {
        if (gethitCD > 0.0f)
        {
            renderIMG.color = getHit;
            gethitCD-=Time.deltaTime;
            if (gethitCD <= 0.0f)
            {
                renderIMG.color = backHit;
            }
        }
    }
}
