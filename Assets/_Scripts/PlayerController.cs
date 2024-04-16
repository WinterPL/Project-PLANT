using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 5;


    private Vector2 movement;
    private Rigidbody2D rb;
    private Vector3 targetCameraPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetCameraPos = Camera.main.transform.position;
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement *speed* Time.fixedDeltaTime);
        // check to see if out of bounds
        // update here
        // get a bounding value
        // then check if player.position.x > value, then move camera right
        // if player.position.x < value, move camera left
        //if (collision.gameObject.tag == "Right")
        //{
        //    targetCameraPos = new Vector3(Camera.main.transform.position.x + speed * Time.fixedDeltaTime, Camera.main.transform.position.y, Camera.main.transform.position.z);
        //}
        //if (collision.gameObject.tag == "Left" && Camera.main.transform.position.x >= 0.0f)
        //{
        //    targetCameraPos = new Vector3(Camera.main.transform.position.x - speed * Time.fixedDeltaTime, Camera.main.transform.position.y, Camera.main.transform.position.z);
        //}
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetCameraPos, Time.fixedDeltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Right" )
        {
            targetCameraPos = new Vector3(Camera.main.transform.position.x + speed*Time.fixedDeltaTime, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        if (collision.gameObject.tag == "Left" && Camera.main.transform.position.x >= 0.0f)
        {
            targetCameraPos = new Vector3(Camera.main.transform.position.x - speed * Time.fixedDeltaTime, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }

    }

    /*    void Update()
        {

            if(Input.GetKey(KeyCode.D))
            {
                Debug.Log("Key D is pressed");


            }
            else if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("Key A is pressed");
                //this.transform.position.x -= 0.1f;
            }

            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("Key W is pressed");
                //this.transform.position.x -= 0.1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("Key S is pressed");
                //this.transform.position.x -= 0.1f;
            }
        }*/
}
