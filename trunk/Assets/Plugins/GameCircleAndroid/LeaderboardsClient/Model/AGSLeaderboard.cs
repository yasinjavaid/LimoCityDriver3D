using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// AGS leaderboard.
/// </summary>
public class AGSLeaderboard{
	public string name;
	public string id;
	public string displayText;
	public string scoreFormat;
	public List<AGSScore> scores = new List<AGSScore>();
	
	public static AGSLeaderboard fromHashtable( Hashtable ht ){
		var board = new AGSLeaderboard();
		board.name = ht["name"].ToString();
		board.id = ht["id"].ToString();
		board.displayText = ht["displayText"].ToString();
		board.scoreFormat = ht["scoreFormat"].ToString();
		
		// handle scores if we have them
		if( ht.ContainsKey( "scores" ) && ht["scores"] is ArrayList )
		{
			var scoresList = ht["scores"] as ArrayList;
			board.scores = AGSScore.fromArrayList( scoresList );
		}
		
		return board;
	}
	
	
	public override string ToString(){
		return string.Format( "name: {0}, id: {1}, displayText: {2}, scoreFormat: {3}", name, id, displayText, scoreFormat );
	}
	
}
