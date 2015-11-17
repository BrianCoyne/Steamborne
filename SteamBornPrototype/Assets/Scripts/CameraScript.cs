using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public int CameraSpeed = 40;
	
	bool _moveForward = false;
	bool _moveBackward = false;
	bool _moveRight = false;
	bool _moveLeft = false;
	
	void Update()
	{
		RTSCamera();   
	}
	
	void RTSCamera()
	{
		if(Input.GetKeyDown(KeyCode.W)){ _moveForward = true; }
		if(Input.GetKeyUp(KeyCode.W)){ _moveForward = false; }
		
		if(Input.GetKeyDown(KeyCode.S)){ _moveBackward = true; }
		if(Input.GetKeyUp(KeyCode.S)){ _moveBackward = false; }
		
		if(Input.GetKeyDown(KeyCode.D)){ _moveRight = true; }
		if(Input.GetKeyUp(KeyCode.D)){ _moveRight = false; }
		
		if(Input.GetKeyDown(KeyCode.A)){ _moveLeft = true; }
		if(Input.GetKeyUp(KeyCode.A)){ _moveLeft = false;}
		
		MoveCamera();  
	}
	
	void MoveCamera()
	{
		if(_moveForward == true){transform.Translate(Vector3.forward * CameraSpeed * Time.deltaTime,Space.World);}
		
		if(_moveBackward == true){transform.Translate(Vector3.back * CameraSpeed * Time.deltaTime,Space.World);}
		
		if(_moveRight == true){transform.Translate(Vector3.right * CameraSpeed * Time.deltaTime,Space.World);}
		
		if(_moveLeft == true){transform.Translate(Vector3.left * CameraSpeed * Time.deltaTime,Space.World);}
	}
}