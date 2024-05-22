using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float HP = 10;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private int MxADMG = 10;
    [SerializeField] private int MnADMG = 5;
    //[SerializeField] private int bDMG = 10;
    [SerializeField] private float HitCD = 5.0f;
    [SerializeField] private bool CanHit = true;
    [SerializeField] private Collider2D[] colliders;

    public bool dummy = false;
    public bool needHeal = false;
    public float healCD = 7.0f;


    public Color Walking;
    public Color Hitting;


    SpriteRenderer sprite;
    enum Behavior
    { 
        walk,
        attack
    };

    private Behavior behave;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        behave = Behavior.walk;
        sprite.color = Walking;
    }

    // Update is called once per frame
    void Update()
    {
        switch (behave)
        {
            case Behavior.walk:
                if (!dummy)
                {
                    this.transform.Translate(Vector3.left * speed * Time.deltaTime);
                    if (HP <= 0)
                    {
                        death();
                    }
                }
                else
                {
                    if (HP < 10)
                    {
                        needHeal = true;
                    }

                    if (needHeal)
                    {
                        healCD -= Time.deltaTime;
                        if (healCD <= 0.0f)
                        {
                            needHeal = false;
                            HP = 10;
                            healCD = 7.0f;
                        }
                    }
                }
                break;
            case Behavior.attack:
                if (HP <= 0)
                {
                    death();
                }
                if (!dummy)
                {
                    if(CanHit)
                    {
                        CanHit = false;
                        int ADMG = Random.Range(MxADMG,MnADMG);
                        GameManager.instance.hp.GotHit(ADMG);
                    }
                    else
                    {
                        sprite.color = Hitting;
                        HitCD -= Time.deltaTime;
                        if(HitCD<=0.0f)
                        {
                            CanHit = true;
                            HitCD = 5.0f;
                        }
                    }
                }

                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("Bullet ENTER");
            if (colliders[0].IsTouching(other))
            {
                //Debug.Log("HEAD");
                HP -= GameManager.Instance.gun.bDamage * 2;
            }
            else if (colliders[1].IsTouching(other))
            {
                //Debug.Log("BODY");
                HP -= GameManager.Instance.gun.bDamage;
            }
            else if (colliders[2].IsTouching(other))
            {
                //Debug.Log("LEG");
                HP -= GameManager.Instance.gun.bDamage;
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
}
