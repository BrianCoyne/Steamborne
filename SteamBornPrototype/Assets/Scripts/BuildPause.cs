using UnityEngine;
using System.Collections;

public class BuildPause : MonoBehaviour {


	public GameObject buildbutton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (Time.deltaTime == 0.0f) 
		{
			buildbutton.SetActive(false);
			BuildingPlacement.Instance.PlacingBuildingIndex = -1;

		} 

		else 
		{
			buildbutton.SetActive(true);
		} 
	}
}
