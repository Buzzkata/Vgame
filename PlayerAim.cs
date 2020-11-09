using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    public bool direction;
    public float angle;
    private Quaternion target;
    

    void Start()
    {

        direction = true;

    }

    void FixedUpdate()
    {
        //get the joystick input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //if the player is trying to aim up, make them aim horizontally
        if(v > 0)
        {
            v = 0;
        }

        //calculate the angle of the joystick
        angle = Mathf.Atan2(h, -v) * Mathf.Rad2Deg;

        //if the joystick is neutral, slowly move back to center
        if(h == 0 && v == 0)
        {
            angle = 0f;
            target = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * 8);
        }
        else //if the joystick isn't neutral, move towards where it's pointed
        {
            target = Quaternion.Euler(0f, 0f, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * 15);
        }
        
        
        //make sure the sprite is facing the right direction
        //true = right, false = left
        if(angle > 0f)
        {
            if(direction == false)
            {
                direction = true;
                Flip();
            }
        }
        else if(angle < 0f)
        {
            if(direction == true)
            {
                direction = false;
                Flip();
            }
        }
    }

    //flip the sprite
    void Flip()
    {
        Vector3 flip = transform.localScale;
        flip.x *= -1;
        transform.localScale = flip;
    }
}
