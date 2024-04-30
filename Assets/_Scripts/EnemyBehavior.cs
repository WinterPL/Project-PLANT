using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float HP = 10;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Collider2D[] colliders;


    [SerializeField] private int bDMG = 0;

    // Start is called before the first frame update
    void Start()
    {
        bDMG = GameManager.Instance.gun.bDamage;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left *speed* Time.deltaTime);

        if(HP <= 0 )
        {
            Destroy(this.gameObject);
            Debug.Log("Dead");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (colliders[0].IsTouching(other))
            {
                HP -= bDMG * 2;
            }
            if (colliders[1].IsTouching(other))
            {
                HP -= bDMG;
            }
            if (colliders[2].IsTouching(other))
            {
                HP -= bDMG;
                if (speed > 0)
                {
                    speed -= 0.5f;
                }
                
            }
        }
    }

}
