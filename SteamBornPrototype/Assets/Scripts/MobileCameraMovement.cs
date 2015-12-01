using UnityEngine;
using System.Collections;

public class MobileCameraMovement : MonoBehaviour
{


	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.1f;        // The rate of change of the orthographic size in orthographic mode.
	Vector3 hit_position = Vector3.zero;
	Vector3 current_position = Vector3.zero;
	Vector3 camera_position = Vector3.zero;
	float z = 0.0f;	
		
	void Update ()
	{
		if(Input.GetMouseButtonDown(0)){
			hit_position = Input.mousePosition;
			camera_position = transform.position;
			
		}
		if(Input.GetMouseButton(0)){
			current_position = Input.mousePosition;
			LeftMouseDrag();        
		}

		// If there are two touches on the device...
		if (Input.touchCount == 2) {
			// Store both touches.
			Touch touchZero = Input.GetTouch (0);
			Touch touchOne = Input.GetTouch (1);
				
			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
				
			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
				
			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
				
			// If the camera is orthographic...
			if (GetComponent<Camera>().orthographic) {
				// ... change the orthographic size based on the change in distance between the touches.
				GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
					
				// Make sure the orthographic size never drops below zero.
				GetComponent<Camera>().orthographicSize = Mathf.Max (GetComponent<Camera>().orthographicSize, 0.1f);
			} else {
				// Otherwise change the field of view based on the change in distance between the touches.
				GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
					
				// Clamp the field of view to make sure it's between 0 and 180.
				GetComponent<Camera>().fieldOfView = Mathf.Clamp (GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
			}
		}
	}

	void LeftMouseDrag(){
		// From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
		// with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
		//current_position.z = hit_position.z = camera_position.y;
		
		// Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
		// anyways.  
		Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);
		
		// Invert direction to that terrain appears to move with the mouse.
		direction = direction * -1;
		
		Vector3 position = camera_position + direction;
		
		transform.position = position;
	}
}