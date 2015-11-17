using UnityEngine;
using System.Collections;

public class BuildButton : MonoBehaviour {

	public GameObject BuildButtonPrefab;

	private Canvas m_canvas;


	// Use this for initialization
	void Start () {

		m_canvas = GetComponent<Canvas> ();

		GameObject obj = Instantiate (BuildButtonPrefab) as GameObject;  

		obj.transform.SetParent(transform, false);


	}

}
