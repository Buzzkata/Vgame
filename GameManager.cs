//Manages gameover and play again 
//The script is called when a player dies, when health is 0
//or when it collides with an indestructable debree.
//Script should be called in PlayerController collision method
//in PlayerController: public GameManager gameManager;
using UnityEngine;
using System.Collections;
using UnityEngine.ScreenManagement;

public class GameManager : MonoBehavior( 
	public GameObject gameOverCanvas; //consists of game over, players score
	void Start(){
		Time.timeScale = 1;
	}
	void GameOver(){
		gameOverCanvas.setActive(true);
		Time.timeScale = 0;
	}
	void Replay(){
		ScreenManager.LoadScene(0); 
		
	}
)

