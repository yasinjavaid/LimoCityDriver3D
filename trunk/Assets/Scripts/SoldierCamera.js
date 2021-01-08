#pragma strict

public var normalFOV = 50;
public var zoomFOV = 15;
public var lerpSpeed = 8.0;
var aim : boolean = false;
public var speed : Vector2 = new Vector2(135.0, 135.0);
public var aimSpeed : Vector2 = new Vector2(70.0, 70.0);
public var maxSpeed : Vector2 = new Vector2(100.0, 100.0);
public var yMinLimit = -90;
public var yMaxLimit = 90;
public var xMinLimit = -45;
public var xMaxLimit = 45;
public var x = 0.0;
public var y = 0.0;
private var singleClickdetact : float = 0.0;
private var isMobile : boolean = false;


function Start () {

}

function Update () {

				
		if(!isMobile)
			GetInput();
		else
			GetInputTouch();
		this.transform.rotation = Quaternion.Euler(y, x, 0);
	//	HitTarget();
}

function GetInput()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			aim = !aim;
			if(aim)
				camera.fieldOfView = 15.0f;//Mathf.Lerp(camera.fieldOfView, zoomFOV, Time.deltaTime * lerpSpeed);
			else
				camera.fieldOfView = 50.0f;//Mathf.Lerp(camera.fieldOfView, normalFOV, Time.deltaTime * lerpSpeed);
		}
		var a : Vector2 = aim ? aimSpeed : speed;
		x += Mathf.Clamp(Input.GetAxis("Mouse X") * a.x, -maxSpeed.x, maxSpeed.x) * Time.deltaTime;
		y -= Mathf.Clamp(Input.GetAxis("Mouse Y") * a.y, -maxSpeed.y, maxSpeed.y) * Time.deltaTime;
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		x = ClampAngle(x, xMinLimit, xMaxLimit);
	}
	
function GetInputTouch()
{
		for(var i = 0; i< Input.touchCount; i++){
			if(Input.GetTouch(i).phase == TouchPhase.Began)
			{
				singleClickdetact = Time.time;
        	}
        	if(Input.GetTouch(i).phase == TouchPhase.Ended)
        	{
        		if ((Time.time - singleClickdetact) < 0.3f)
				{
					aim = !aim;
					if(aim)
						camera.fieldOfView = 15.0f;//Mathf.Lerp(camera.fieldOfView, zoomFOV, Time.deltaTime * lerpSpeed);
					else
						camera.fieldOfView = 50.0f;//Mathf.Lerp(camera.fieldOfView, normalFOV, Time.deltaTime * lerpSpeed);
				}
        	}
			if (Input.GetTouch(i).phase == TouchPhase.Moved)
			{
				var a : Vector2 = aim ? aimSpeed : speed;
				x += Mathf.Clamp(Input.GetAxis("Mouse X") * a.x, -maxSpeed.x, maxSpeed.x) * Time.deltaTime;
				y -= Mathf.Clamp(Input.GetAxis("Mouse Y") * a.y, -maxSpeed.y, maxSpeed.y) * Time.deltaTime;
				y = ClampAngle(y, yMinLimit, yMaxLimit);
				x = ClampAngle(x, xMinLimit, xMaxLimit);
				print ("x position : " + x + "   y position : " + y);
			}
		
		}
}

	static function ClampAngle(angle : float, min : float, max : float) : float
	{
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

function HitTarget()
{
		//var ray : Ray = camera.ScreenPointToRay (Vector3(440,200,0));
		var ray : Ray = camera.ViewportPointToRay (Vector3(0.5,0.5,0));
        Debug.DrawRay (ray.origin, ray.direction * 100, Color.yellow);
        var hit : RaycastHit;
        if (Physics.Raycast (ray, hit))
            print ("I'm looking at " + hit.transform.name);
        else
            print ("I'm looking at nothing!");
}