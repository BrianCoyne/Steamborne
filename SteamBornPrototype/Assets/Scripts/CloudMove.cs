﻿using UnityEngine;
using System.Collections;

public class CloudMove : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
		transform.Translate(Vector3.left * Time.deltaTime * 0.2f);
        
	}
}
