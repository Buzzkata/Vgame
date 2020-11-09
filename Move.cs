//debrees go up, i.e. player goes down
//script is a component to the debree spawner object
using UnityEngine;
using System.Collections;
public class Move : MonoBehavior { //component needs to be added to debree object

	public float speedUp;
	void Start(){
		speedUp = 0f;
	}
	void FixedUpdate(){
		transform.position += Vector3.up*speedUp; //might need some tweaking
		speedUp += Time.deltaTime;//speed up accelerator that increases speed constantly
	}

}