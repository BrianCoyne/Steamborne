using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RivetText : MonoBehaviour {

	public Text textrivetobject;
	
	// Use this for initialization
	void Start () {
		textrivetobject = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		textrivetobject.text = "Rivets = " + BuildingPlacement.Instance.CurrentRivets;
	}
}

