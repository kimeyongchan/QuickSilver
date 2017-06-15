using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_trigger : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Debug.Log("crush");
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
