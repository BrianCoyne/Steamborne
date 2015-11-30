using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{

	public Ray cameraRay;
	RaycastHit hitInfo;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;

			if (Physics.Raycast (cameraRay, out hitInfo, 1000)) {
				Debug.Log(hitInfo.collider.gameObject.name);
				Debug.Log("You hit" + gameObject.name);
				
				Button bt = hitInfo.collider.gameObject.GetComponent<Button> ();

				if (bt != null)
				{
					bt.ToggleDoor ();
				}
			}

		}
	}

}
