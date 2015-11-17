using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentWorkersPop : MonoBehaviour {

	public Text textobject;
	
	// Use this for initialization
	void Start () {
		textobject = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		textobject.text = "Population: " + BuildingPlacement.Instance.CurrentPopulation + " / Workers: " + BuildingPlacement.Instance.CurrentWorkers;
}
}

