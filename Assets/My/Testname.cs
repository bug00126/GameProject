using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testname : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        print("Othertag = " + other.collider.gameObject.tag);
        print("Othername = " + other.collider.gameObject.name);
        print("Mytag = " + gameObject.tag);
        print("Myname = " + gameObject.name);
    }
}
