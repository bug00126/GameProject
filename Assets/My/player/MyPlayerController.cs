using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour {

    private float x;
    private float y;
    private float speed = 100.0f;
    private Quaternion myrotation;
    private Animator animator;
    private Transform playerCamera;
    // Use this for initialization
    void Start () {
        playerCamera = transform.Find("FirstPersonCharacter");
        animator =GetComponentInChildren< Animator >();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("space"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0.0f, 500.0f, 0.0f);
        }
        if (Input.GetKeyDown("a"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce((playerCamera.forward + new Vector3(0.0f, 0.1f, 0.0f ) )* 500.0f);
        }
        if(Input.GetButtonDown("Fire2")||Input.GetKeyDown("s"))
        {
            animator.SetBool("attack", true);
        }
        if(Input.GetButtonUp("Fire2")||Input.GetKeyUp("s"))
        {
            animator.SetBool("attack", false);
        }
        x += Input.GetAxis("Mouse X") * (1)*speed * Time.deltaTime;
        y += Input.GetAxis("Mouse Y") * (-1)* speed * Time.deltaTime;
        if(x>360)
        {
            x -= 360;
        }
        else if(x<0)
        {
            x += 360;
        }
        myrotation = Quaternion.Euler(y, x, 0);
        transform.rotation = myrotation;

    }
    private void FixedUpdate()
    {

        if (Input.GetKey("up"))
        {
            y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            y += speed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            x += speed * Time.deltaTime;
        }
        myrotation = Quaternion.Euler(y, x, 0);
        transform.rotation = myrotation;
    }
}
