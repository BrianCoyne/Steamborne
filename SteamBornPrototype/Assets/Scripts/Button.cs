using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject obj;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void ToggleDoor () 
	
	{
		if (obj.active == true) 
		{
			obj.SetActive(false);
		} 
		else if (obj.active == false) 
		{
			obj.SetActive(true);
		}
	}
}
