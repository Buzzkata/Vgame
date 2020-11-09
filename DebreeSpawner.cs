//Script that spawns new debree objects.
//It is a component of the Debree spawner objects
//that will keep spawning them over and over
using UnityEngine;
using System.Collections;
public class DebreeSpawner : MonoBehavior{
	public float maxTime;
	public float timer;
	public GameObject debree;
	
	public float backSpeed;
	
	
	void Start(){
		timer = 0f;
		maxTime = 1f;
		
	}
	void Update(){
		if(timer>maxTime){
		GameObject newDebree = Instantiate(debree);
		//newDebree.transform.position = transform.position + new Vector3(0,Random.Range
		Destroy(newDebree, 20); //destroys the newdebree objects after time 20 to prevent infinite object spawn
		timer = 0f; 
		}
		timer += Timer.deltaTime;
		//the new debree objects are gonna spawn
	}
}