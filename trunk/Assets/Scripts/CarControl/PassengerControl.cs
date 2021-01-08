using UnityEngine;
using System.Collections;

public class PassengerControl : MonoBehaviour {
	
	protected  Animator animator;
	GameObject TargetDoor=new GameObject();
	private bool doordetected ;
	private bool LevelCompleteStatus=false;
	// Use this for initialization
	void Start () 
	{
		
		doordetected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.PARKED)
		{
			if(gameObject.tag.Contains("Passenger"))
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(-this.transform.position + GameObject.FindGameObjectWithTag("Door").transform.position, new Vector3(0,0,0) ), 0.01f);
			if(doordetected)
			{
			// this.transform.LookAt(TargetDoor.transform);
			//var newRotation = Quaternion.LookRotation(transform.position - target.transform.position, Vector3.forward); 

				//this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(-this.transform.position + GameObject.FindGameObjectWithTag("Door").transform.position, new Vector3(0,0,0) ), 0.01f);
				if(Vector3.Distance(gameObject.transform.position,TargetDoor.transform.position)<35)
				{
					animator.SetBool("IsEnter",true);
					Destroy(gameObject,2);	
					if(!LevelCompleteStatus)
					{
						GameObject.FindGameObjectWithTag("Player").SendMessage("CompleteLevel");
						LevelCompleteStatus=true;
					}
				}
			}
		}
	}
	
	public void startWalking(){
		
		TargetDoor=GameObject.FindGameObjectWithTag("Door");
		doordetected = true;
		animator = GetComponent<Animator>();
		animator.SetBool("IsWalk",true);
	}

	
}
