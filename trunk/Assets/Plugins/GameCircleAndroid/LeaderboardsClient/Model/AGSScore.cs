using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// AGS score.
/// </summary>
public class AGSScore{
	public string playerAlias;
	public int rank;
	public string scoreString;
	public long scoreValue;
	
	
	public static AGSScore fromHashtable( Hashtable ht ){
		var score = new AGSScore();
		score.playerAlias = ht["playerAlias"].ToString();
		score.rank = int.Parse( ht["rank"].ToString() );
		score.scoreString = ht["scoreString"].ToString();
		score.scoreValue = long.Parse( ht["scoreValue"].ToString() );
		
		return score;
	}
	
	
	public static List<AGSScore> fromArrayList( ArrayList list ){
		var scores = new List<AGSScore>();
		
		foreach( Hashtable ht in list ){
			scores.Add( AGSScore.fromHashtable( ht ) );
		}
		
		return scores;
	}
	
	
	public override string ToString(){
		return string.Format( "playerAlias: {0}, rank: {1}, scoreString: {2}", playerAlias, rank, scoreString );
	}
	
}
