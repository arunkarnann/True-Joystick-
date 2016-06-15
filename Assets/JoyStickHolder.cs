using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class JoyStickHolder : MonoBehaviour,IPointerDownHandler, IPointerUpHandler {


	public Transform Joystick;

	public void OnPointerDown(PointerEventData data){
		print(data.delta.x+""+data.delta.y.ToString());
		print(data.position.ToString());
		Joystick.position =  new Vector3(data.position.x,data.position.y,0);
	}
	public void OnPointerUp(PointerEventData data){
		Joystick.position =  new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);
	}

}
