using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float reload; 
    public float health; //hp
    public Transform shot;
    public Transform angle;

    private Vector2 velocity; //the velocity of the player
    private Rigidbody2D playerBody;
    private float h; //stores the horizontal axis multiplied by a set value
    private float decel; //the rate at which the player will decelerate

    void Start()
    {
        //set starting values
        playerBody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        reload = 0f;
        health = 100f;
        decel = 15;
    }

    void FixedUpdate()
    {

        //get input from the joysticks
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //if the player fires and the gun isn't reloading
        if (Input.GetButton("Jump") && reload == 0f)
        {

            //if the y axis is above 0, make it 0
            if(moveVertical > 0)
            {
                moveVertical = 0;
            }

            //get the position of the gun
            Vector3 pos = new Vector3((angle.transform.position.x + moveHorizontal), (angle.transform.position.y + moveVertical), 0f);
            Instantiate(shot, pos, angle.transform.rotation); //shoot

            //give reload a value
            reload = 1;

            //get the direction the player was aiming and set h
            if (moveHorizontal > 0) //if the player is aiming right, make it so we move left
            {
                if (moveHorizontal < 0.4)
                {
                    h = (15 / 2) * 0.4f;
                    h = -h;

                    decel = 15 / 2;
                }
                else
                {
                    h = 15 * -moveHorizontal;

                    decel = 15;
                }
            }
            else if (moveHorizontal < 0) //if the player is aiming left, make sure we move right
            {
                if (moveHorizontal > -0.4)
                {
                    h = (15 / 2) * -0.4f;
                    h = -h;

                    decel = 15 / 2;
                }
                else
                {
                    h = 15 * moveHorizontal;
                    h = -h;

                    decel = 15;
                }
            }

            velocity = new Vector2(h, 0f); //set velocity using h
            
        }

        //as long as h does not equal 0
        if (h != 0)
        {

            //move the player
            playerBody.MovePosition(playerBody.position + velocity * Time.fixedDeltaTime);

            //check which direction the player is moving and decelerate accordingly
            if (h < 0) //if h is less than zero, decelerate to the left
            {
                
                h += (Time.fixedDeltaTime * decel);

                //check if h is greater than or equal to 0, if it is set it to 0
                if (h >= 0)
                {
                    h = 0;
                }

            }
            else if (h > 0) //if h is greater than 0, decelerate to the right
            {
                h -= (Time.fixedDeltaTime * decel);

                //check if h is less than or equal to 0, if it is set it to 0
                if (h <= 0)
                {
                    h = 0;
                }
            }

            velocity.Set(h, 0f); //set velocity using the modified value of h
            //time -= (Time.fixedDeltaTime); //decrease time
        }

        //control the reload delay
        if (reload > 0f)
        {
            reload -= Time.fixedDeltaTime;
        }
        else
        {
            reload = 0;
        }

    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "indestructable")
        {
            health = 0;
			//kill the player
        }
        else if (col.gameObject.tag == "destructable")
        {
            Destroy(col.gameObject);
            health -= 25;
        }
    }

}
