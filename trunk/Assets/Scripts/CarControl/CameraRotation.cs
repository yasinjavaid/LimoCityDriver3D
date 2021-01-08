using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

bool  click ;
Vector3 preXY;
Vector3 postXY ;
Vector2 touch0;
Vector2 touch1;
float distance;
float preDistance;
public static bool  isBtnClicked = false;
public Vector2 speed = new Vector2(135.0f, 135.0f);
public Vector2 maxSpeed = new Vector2(100.0f, 100.0f);
private int yMinLimit= -7;
private int yMaxLimit= 20;
public int xMinLimit= 0;
public int xMaxLimit= 180;
public static float x= 0.0f;
public static float y= 20.0f;
public static float rotationFactor = 0;

float minZoom = 1.0f;
float maxZoom = 5.0f;
	// Update is called once per frame
	void Start()
	{
		//  x= 0.0f;
		  y= 20.0f;
		
	}
	void  FixedUpdate (){
		
		
		if(!isBtnClicked && GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
			
			#if UNITY_EDITOR
//				ForComputer();
			#else
			//	GetInputTouch();
			#endif
		/*	if (Input.touchCount >= 2)
			{
			   	preDistance = distance;
			    touch0 = Input.GetTouch(0).position;
			    touch1 = Input.GetTouch(1).position;
			    distance = Vector2.Distance(touch0, touch1);
			    if(preDistance>distance){
			    	if(SmoothFollow.distance > minZoom){
			    		SmoothFollow.distance = SmoothFollow.distance-.1f;
			    	}
			    	
			    	Debug.Log("Zoom In");
			    }
			    if(preDistance<distance){
			    	if(SmoothFollow.distance < maxZoom){
			    		SmoothFollow.distance = SmoothFollow.distance+.1f;
			    	}
			    	Debug.Log("Zoom Out");
			    }
			}
			else if (Input.touchCount == 1){
				
				if(Input.GetTouch(0).phase == TouchPhase.Began)
				{
					click = true ;
					preXY = Input.mousePosition;
					postXY = preXY;				
				}
				
				if(Input.GetTouch(0).phase == TouchPhase.Ended)
				{
					click = false ;
				}
				
			 	if ( click )
			 	{
					preXY = postXY;
			 		postXY = Input.mousePosition;
			 	}
			 	
				if ( click )
				{
			 		
				 	if (postXY.x > preXY.x)
		 			{
		 				this.gameObject.transform.Rotate(0,-3,0);
				 	}
		 			if  (postXY.x < preXY.x )
				 	{
				 		this.gameObject.transform.Rotate(0,3,0);
		 			}
		 			if (postXY.y > preXY.y)
		 			{
		 				if(SmoothFollow.height>=3 && SmoothFollow.height<=5  ){
		 					SmoothFollow.height = SmoothFollow.height+.1f;
		 					SmoothFollow.distance = SmoothFollow.distance-.1f;
		 				}else if(SmoothFollow.height<=5){
		 					SmoothFollow.height = SmoothFollow.height+.1f;
		 					Debug.Log("Smoothfollow.height" + SmoothFollow.height);
		 				}
				 	}
		 			if  (postXY.y < preXY.y )
				 	{
				 		if(SmoothFollow.height>=3 ){
		 					SmoothFollow.height = SmoothFollow.height-.1f;
		 					SmoothFollow.distance = SmoothFollow.distance+.1f;
		 				}else if(SmoothFollow.height>.5f){
		 					SmoothFollow.height = SmoothFollow.height-.1f;
		 					Debug.Log("Smoothfollow.height" + SmoothFollow.height);
		 				}
		 			}
		 			
				}	
				
			}
			*/ 	
		}
		else{
			click = false;
		}
		
	}
	void  GetInputTouch (){
		for(int i= 0; i< Input.touchCount; i++){
			
    		if (Input.GetTouch(i).phase == TouchPhase.Moved )
			{
				if(Input.GetTouch(i).position.x > Screen.width / 1.5f && Input.GetTouch(i).position.y < Screen.height / 2.5f
					||
					Input.GetTouch(i).position.x < Screen.width / 2.8f && Input.GetTouch(i).position.y < Screen.height / 2.5f)
				{
				}
				else{
					Vector2 a =speed;
					x += Mathf.Clamp(Input.GetAxis("Mouse X") * a.x, -maxSpeed.x, maxSpeed.x) * Time.deltaTime;
					y -= Mathf.Clamp(Input.GetAxis("Mouse Y") * a.y, -maxSpeed.y, maxSpeed.y) * Time.deltaTime;
					y = ClampAngle(y, yMinLimit, yMaxLimit);
					//x = ClampAngle(x, xMinLimit, xMaxLimit);	
					this.transform.rotation = Quaternion.Euler(y, x, 0);
				}
			}
			
		}
	}
	static float ClampAngle ( float angle ,   float min ,   float max  ){
		if (angle < -360)
		{
			angle += 360;
		}
		
		if (angle > 360)
		{
			angle -= 360;
		}
		
		return Mathf.Clamp (angle, min, max);
	}
	private void ForComputer(){
		if(!isBtnClicked){
			
			if(Input.mousePosition.x > Screen.width / 1.5f && Input.mousePosition.y < Screen.height / 2.5f
					||
					Input.mousePosition.x < Screen.width / 2.8f && Input.mousePosition.y < Screen.height / 2.5f)
				{
				}
				else{
				Vector2 a =speed;
				x += Mathf.Clamp(Input.GetAxis("Mouse X") * a.x, -maxSpeed.x, maxSpeed.x) * Time.deltaTime;
				y -= Mathf.Clamp(Input.GetAxis("Mouse Y") * a.y, -maxSpeed.y, maxSpeed.y) * Time.deltaTime;
					y = ClampAngle(y, yMinLimit, yMaxLimit);
				//	x = ClampAngle(x, xMinLimit, xMaxLimit);	
				Debug.Log(x +"     " + y);
					this.transform.rotation = Quaternion.Euler(y, x, 0);
				
			}
			
			if ( Input.GetMouseButtonDown(0) )
			{
				click = true ;
				preXY = Input.mousePosition;
				postXY = preXY;
				
			}
			if ( Input.GetMouseButtonUp(0) )
			{
		       	click = false ;
		 	}
			if ( click )
			{
				preXY = postXY;
			 	postXY = Input.mousePosition;
			}
			if ( click )
			{
		 		
			 	if (postXY.x > preXY.x)
	 			{
	 				this.gameObject.transform.Rotate(0,-3,0);
			 	}
	 			if  (postXY.x < preXY.x )
			 	{
			 		this.gameObject.transform.Rotate(0,3,0);
	 			}
	 			if (postXY.y > preXY.y)
	 			{
	 				if(SmoothFollow.height>=3 && SmoothFollow.height<=5  ){
	 					SmoothFollow.height = SmoothFollow.height+.1f;
	 					SmoothFollow.distance = SmoothFollow.distance-.1f;
	 				}else if(SmoothFollow.height<=5){
	 					SmoothFollow.height = SmoothFollow.height+.1f;
	 					Debug.Log("Smoothfollow.height" + SmoothFollow.height);
	 				}
			 	}
	 			if  (postXY.y < preXY.y )
			 	{
			 		if(SmoothFollow.height>=3 ){
	 					SmoothFollow.height = SmoothFollow.height-.1f;
	 					SmoothFollow.distance = SmoothFollow.distance+.1f;
	 				}else if(SmoothFollow.height>-0.1f){
	 					SmoothFollow.height = SmoothFollow.height-.1f;
	 					Debug.Log("Smoothfollow.height" + SmoothFollow.height);
	 				}
	 			}
	 			
			}
			else{
				click = false;
			}
		}	
		
	}
}