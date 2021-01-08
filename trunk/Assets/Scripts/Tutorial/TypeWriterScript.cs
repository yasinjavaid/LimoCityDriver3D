using UnityEngine;

/// <summary>
/// Trivial script that fills the label's contents gradually, as if someone was typing.
/// </summary>

[RequireComponent(typeof(UILabel))]
[AddComponentMenu("NGUI/Examples/Typewriter Effect")]
public class TypeWriterScript : MonoBehaviour
{
	public int charsPerSecond = 40;
   public AudioClip typeSound; 
	
   UILabel mLabel;
   string mText;
   int mOffset = 0;
   float mNextChar = 0f;
   
   void OnEnable(){
      mLabel = GetComponent<UILabel>();
      mLabel.enabled = false;
      mLabel = null;
   }
   
    void Start(){
      
   }
   
   public void FinishTypewriter(){
      mLabel.text  = mText;               
      //Destroy(this);
   }
   
   
   
   void Update ()
   {
      if (mLabel == null)
      {      
         mLabel = GetComponent<UILabel>();
         
		setTutorialText(mLabel);
			
         mLabel.enabled = true;
         mLabel.symbolStyle = UIFont.SymbolStyle.None;			
         mText = mLabel.font.WrapText(mLabel.text, mLabel.lineWidth / mLabel.cachedTransform.localScale.x, mLabel.maxLineCount, true, UIFont.SymbolStyle.None);
      }
      if (mOffset < mText.Length)
      {
         if (mNextChar <= Time.time)
         {
            charsPerSecond = Mathf.Max(1, charsPerSecond);
            // Periods and end-of-line characters should pause for a longer time.
            float delay = 1f / charsPerSecond;
            char c = mText[mOffset];
            if (c == '.' || c == ',' || c == '!' || c == '?' /*|| c == ' '*/) delay *= 4f;
            
            string s = mText.Substring(0, ++mOffset);
            if(c == '['){
               for(int i = 0;i< 20; i++)	
				{
                     s = mText.Substring(0, ++mOffset);
                     int index2 = s.IndexOf(']',mOffset - 1);
                     if(index2 != -1 ){
                        break;
                     }
                  }
            }
            else if(c == '\\')
			{
                  s = mText.Substring(0, ++mOffset);
            }
            mLabel.text  = s;               
            if(typeSound != null)
			{
				audio.PlayOneShot(typeSound);
            }
            mNextChar = Time.time + delay;
         }
      }
     // else Destroy(this);
   }

	/*void OnGUI() 
	{
        if (GUI.Button(new Rect(0, 10, 100, 60), "Replay"))
		{    
   			 mOffset = 0;
   			 mNextChar = 0f;
			 mLabel.text="";
    	}
		
		if (GUI.Button(new Rect(Screen.width-100, 0, 100, 60), "Reset Speed"))
		{    
   			 charsPerSecond = 40;
    	}
		
		if (GUI.Button(new Rect(0, 110, 120, 60), "Decrease Speed"))
		{    
   			 charsPerSecond=charsPerSecond-5;
    	}
		if (GUI.Button(new Rect(Screen.width-120, 110, 120, 60), "Increase Speed"))
		{
			charsPerSecond=charsPerSecond+5;
    	}
	}*/
	
	public void displayInstruction(string newInstruction)
	{
		Debug.Log("displaying instruction########");	
		mOffset = 0;
   			 mNextChar = 0f;
   			 
			 mText=newInstruction;
	}
	
	private void setTutorialText(UILabel pLabel){
		switch(UserPrefs.TutorialStep){
			case 1:
				pLabel.text = "Left/Right Steering\nControls";
				break;
			case 2:
				pLabel.text = "Accelaration & Brake\nControls";
				break;
			case 3:
				pLabel.text = "Watch out the Timer for\nthe time count!";
				break;			
			case 4:
				pLabel.text = "Celebrity Waiting!";
				break;
			case 5:
				pLabel.text = "Park at the green\nindicated area!";
				break;
			case 6:
				pLabel.text = "Apply brakes for\nparking";
				break;			
			case 7:
				pLabel.text = "Wait 10 seconds for the\nsignal to turn green!\nAvoid hitting traffic!";
				break;
			case 8:
				pLabel.text = "Go! for destination";
				break;
			
			default:
				pLabel.text = "";
				break;
			
		}
	}
}
