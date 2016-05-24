using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickAk : MonoBehaviour,IDragHandler,IPointerUpHandler,IEndDragHandler {

	public Vector3 TouchPosition;
	public Vector2 RectangleForScroll;
	public Vector3 startPos; 
	public enum InputAxe{Horizontal,Vertical,Both};
	public InputAxe InputAxis;
	public bool IsMouseDown;
	public bool AutoHideJoystick;
	public Vector3 InitialMouseClickPosition;
	public float Horizontal;
	public float Vertical;

	public Text TxtHorizontal;
	private RectTransform JoystickRectTransfrom;

	void Start(){
		JoystickRectTransfrom = this.GetComponent<RectTransform>();
	}
	void LateUpdate(){
		if(InputAxis == InputAxe.Horizontal){
			
		}
		else if(InputAxis == InputAxe.Vertical){
			
		}
		else{
			
		}

		if(Input.GetMouseButtonUp(0)){
			//this.GetComponent<Image>().CrossFadeAlpha(0,0.1f,true);
			IsMouseDown = false;

		}
		else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= RectangleForScroll.x){
			print("Yes Down");
			startPos = Input.mousePosition;
			this.GetComponent<Image>().CrossFadeAlpha(1,0.1f,true);
			IsMouseDown = true;
			InitialMouseClickPosition = Input.mousePosition;
		}
		if(Input.mousePresent && IsMouseDown){
			TouchPosition = Input.mousePosition;
			if(Input.mousePosition.x <= RectangleForScroll.x)
			this.transform.transform.position = new Vector3(Input.mousePosition.x,InitialMouseClickPosition.y,this.transform.position.z);	
		}
	}



	public  void OnPointerUp(PointerEventData data)
	{
		if(AutoHideJoystick){
			this.GetComponent<Image>().CrossFadeAlpha(0,0.1f,true);
			print("Mouse Up");
			Horizontal=0f;
		}
	}

	public void OnEndDrag(PointerEventData data){
		
		if(AutoHideJoystick){
			this.GetComponent<Image>().CrossFadeAlpha(0,0.1f,true);
			print("End Drag");
			Horizontal=0f;
		}
	}


	public  void OnDrag(PointerEventData data) {
		if(AutoHideJoystick){
			//Setting this for calculation
			Vector3 newPos = Vector3.zero;


			int deltax = (int) (data.position.x - startPos.x);
			deltax = Mathf.Clamp (deltax, - Mathf.FloorToInt(RectangleForScroll.x), Mathf.FloorToInt(RectangleForScroll.x));
			newPos.x = deltax;

			int deltay = (int)(data.position.y - startPos.y);
			deltay = Mathf.Clamp (deltay, Mathf.FloorToInt(-RectangleForScroll.x), Mathf.FloorToInt(RectangleForScroll.y));
			newPos.y = deltay;
			if(startPos.x + newPos.x<= RectangleForScroll.x)
			transform.position = new Vector3(startPos.x + newPos.x , InitialMouseClickPosition.y,this.transform.position.z);
		//UpdateVirtualAxes (transform.position);
			//TouchPosition = transform.position;
		}

		//Calculation   /JoystickRectTransfrom.localPosition.x
		//Horizontal = (JoystickRectTransfrom.localPosition.x )/ ((RectangleForScroll.x - InitialMouseClickPosition.x) / 2f);
		Horizontal =Mathf.Clamp(  (JoystickRectTransfrom.position.x - InitialMouseClickPosition.x)/ ((RectangleForScroll.x) / 2f), -1 , 1);
		TxtHorizontal.text = Horizontal.ToString();
	
	}

}
