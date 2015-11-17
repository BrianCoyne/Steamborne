using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentHousingText : MonoBehaviour {

	public Text textobject;
	
	// Use this for initialization
	void Start () {
		textobject = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		textobject.text = "Housing = " + BuildingPlacement.Instance.CurrentHousing;
	}
}

