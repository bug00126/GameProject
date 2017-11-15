using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {
	private const float size = 150;
	private const float begin = -50;

	public GameObject balloon;
	// Use this for initialization
	void Start () {
		for (int i=0; i<size; i++) {
			for (int j=0; j<size; j++) {
				Instantiate(balloon);
				balloon.transform.position = new Vector3((float)(begin + (float)i*0.6), -1.3f, (float)(begin + (float)j*0.6));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
