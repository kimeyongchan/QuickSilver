using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Vector3 sight_up = new Vector3(0,0, -1);
    public Vector3 sight_down = new Vector3(0,0, 1);
    public Vector3 sight_left = new Vector3(-1,0, 0);
    public Vector3 sight_right = new Vector3(1,0,0);

    public Vector3 sight;

    public Vector3 moveDestination;
    public float moveSpeed = 10.0f;

    void Awake()
    {
        moveDestination = transform.position;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
    }

    public virtual void TurnUpdate() { }
}
