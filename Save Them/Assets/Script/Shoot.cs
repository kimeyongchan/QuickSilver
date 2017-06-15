using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public Rigidbody bullet;
    public Transform GunEnd;
    private AudioSource GunShot;

    void Start ()
    {
        GunShot = GetComponent<AudioSource> ();
    }
    void Update () {
        
		if(Input.GetMouseButtonDown(1))
        {
            GunShot.Play();
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(bullet, GunEnd.position, GunEnd.rotation) as Rigidbody;
            bulletInstance.AddForce(GunEnd.forward * 5000);
        }
	}
}
