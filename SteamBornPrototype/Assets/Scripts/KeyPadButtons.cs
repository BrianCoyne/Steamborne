using UnityEngine;
using System.Collections;

public class KeyPadButtons : MonoBehaviour {

	public Ray cameraRay;
	RaycastHit hitInfo;
	public GameObject obj;
	public TextMesh PasswordText;

	private string m_enteredPassword = "";
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			
			if (Physics.Raycast (cameraRay, out hitInfo)) 
			{
				KeyPadNumber keyPadNumber = hitInfo.transform.root.gameObject.GetComponent<KeyPadNumber>();

				if (hitInfo.collider.tag == "ClearButton")
				{
					m_enteredPassword = "";
				}

				if (keyPadNumber != null)
				{
					Debug.Log("You hit " + keyPadNumber.padNumber);

					if (m_enteredPassword.Length < 6)
					{
					m_enteredPassword += keyPadNumber.padNumber;

					
					}



				}
				Debug.Log("Password is now: " + m_enteredPassword);
				
				PasswordText.text = m_enteredPassword;
			}
		}

		if (m_enteredPassword == "1234")
		{

				if (obj.active == true) 
				{
					obj.SetActive(false);
				} 
				else if (obj.active == false) 
				{
					obj.SetActive(true);
				}
			m_enteredPassword = "";
			PasswordText.text = m_enteredPassword;
		}
	}
}