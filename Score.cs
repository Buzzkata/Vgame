//Keeps track of score
//Script added as a component to the score canvas object
//that displays the players score at all times
using UnityEngine;
using System.Collections;
public class Score : MonoBehavior{ 
	private int score;
	void Start(){
		score = 0;
	}
	void FixedUpdate(){
		score+=Time.deltaTime; //score added based on time alive
		getComponent<UnityEngine.UI.Text>().text = score.toString();
	}
	
}