using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentVoltText : MonoBehaviour {

	public Text textvoltobject;
	
	// Use this for initialization
	void Start () {
		textvoltobject = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		textvoltobject.text = "Volts = " + BuildingPlacement.Instance.CurrentVolts;
	}
}

