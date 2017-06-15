using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPlayer : Player {
    Vector3 movement;
    Rigidbody rigdbody;
	// Use this for initialization
    void Awake()
    {
         rigdbody = GetComponent<Rigidbody>();

    }
    void Start () {
        this.transform.Rotate(new Vector3(0,0,0));
	}
    /*
    public void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Run(h, v);
    }*/
    // Update is called once per frame
    private Vector3 targetPosition;
    void Update () {
        targetPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            this.transform.Translate(Vector3.left*5,Space.World);
            //this.transform.Rotate(new Vector3(0, -90, 0), Space.World);
            print(targetPosition);
            targetPosition.x -= 90f;
            this.transform.LookAt(targetPosition);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            this.transform.Translate(Vector3.forward*5, Space.World);
            print(targetPosition);
            targetPosition.z += 90f;
            this.transform.LookAt(targetPosition);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            this.transform.Translate(Vector3.right*5, Space.World);
            print(targetPosition);
            targetPosition.x += 90f;
            this.transform.LookAt(targetPosition);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            this.transform.Translate(Vector3.back*5, Space.World);
            print(targetPosition);
            targetPosition.z -= 90f;
            this.transform.LookAt(targetPosition);
        }
        
    }

    //
    void Run(float h , float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized;
        rigdbody.MovePosition(transform.position + movement);
        print( h);
    }
    
    void Turn()
    {
        Quaternion newRotation = Quaternion.LookRotation(movement);

        rigdbody.MoveRotation(newRotation);
    }
    /*
    void LookUpdate()
    {
        //방향의 변환에 따라 캐릭터도 천천히 회전
        //Quaternion R = Quaternion.LookRotation(lookDirection = h * Vector3.forward + v * Vector3.right;
);
       // transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 10f);
    }*/
}
