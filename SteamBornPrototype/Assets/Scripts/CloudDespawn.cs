using UnityEngine;
using System.Collections;

public class CloudDespawn : MonoBehaviour {

    public float timer;
	// Use this for initialization
	void Start () 
    {
	        
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += 1.0F * Time.deltaTime;
        if (timer >= 300)
        {
            GameObject.Destroy(gameObject);
        }
	}
}
