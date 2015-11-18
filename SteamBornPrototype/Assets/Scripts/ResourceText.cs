using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceText : MonoBehaviour {

	public Text textresourceobject;
	
	// Use this for initialization
	void Start () {
		textresourceobject = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		textresourceobject.text = "" + BuildingPlacement.Instance.CurrentPopulation + "/" + BuildingPlacement.Instance.CurrentHousing + "     " + BuildingPlacement.Instance.CurrentRivets + "     " + BuildingPlacement.Instance.CurrentVolts;
	}
}	