using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private int HP = 10;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private BoxCollider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left *speed* Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(colliders[0].IsTouching(other))
        {
            Debug.Log(this.gameObject.name + " Trigger " + other.gameObject.name);
            HP--;
        }
        if(colliders[1].IsTouching(other))
        {
            Debug.Log(this.gameObject.name + " Trigger " + other.gameObject.name);
            HP--;
        }
        if(colliders[2].IsTouching(other))
        {
            Debug.Log(this.gameObject.name + " Trigger " + other.gameObject.name);
            speed = 0.0f;
        }
    }

}
