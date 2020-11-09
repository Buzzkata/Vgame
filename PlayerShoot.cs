using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Transform fireTransform;
    public bool direction;
    private Quaternion target;

    // Start is called before the first frame update
    void Start()
    {

        direction = true;

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(v > 0)
        {
            v = 0;
        }

        float angle = Mathf.Atan2(h, -v) * Mathf.Rad2Deg;

        if(h == 0 && v == 0)
        {
            target = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * 8);
        }
        else
        {
            target = Quaternion.Euler(0f, 0f, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * 15);
        }
        
        /*
        if(angle > 0f && angle < 100f || angle < 0f && angle > -90f)
        {
            if(direction == false)
            {
                direction = true;
                Flip();
            }
        }
        else if(angle > 100f && angle < 180f || angle < -90f && angle > -180f)
        {
            if(direction == true)
            {
                direction = false;
                Flip();
            }
        }
        */
    }

    /*
    void Flip()
    {
        fireTransform.Rotate(Vector3.forward * 180);

        Vector3 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }
    */
}
