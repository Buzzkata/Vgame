using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    private float time = 0.1f;
    


    void Start()
    {
        Destroy(gameObject, time);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "destructable" || col.gameObject.tag == "indestructable")
        {
            Destroy(gameObject);
        }
    }
}
