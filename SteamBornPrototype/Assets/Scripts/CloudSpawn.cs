using UnityEngine;
using System.Collections;

public class CloudSpawn : MonoBehaviour {

    public GameObject[] obj;
    

    public float spawnMin = 5f;
    public float spawnMax = 10f;
	// Use this for initialization
	void Start () {
        Spawn();
	}

    void Update ()
    {
       
    }
	
	// Update is called once per frame
	void Spawn()
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
        
	}
}
