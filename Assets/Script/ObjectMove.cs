using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour {

    [SerializeField]
    private float ObjectSpeed;
    private Rigidbody2D ObjectBody;
    private BoxCollider2D ObjectCollider;
	// Use this for initialization
	void Start () {
        ObjectBody = GetComponent<Rigidbody2D>();
        ObjectCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag == "LiserR")
        {
            ObjectBody.velocity = Vector2.left * ObjectSpeed;
            if (transform.position.x < -3.84f)
            {
                Destroy(gameObject);
            }

        }
        if (gameObject.tag == "LiserL")
        {
            ObjectBody.velocity = Vector2.right * ObjectSpeed;
            if(transform.position.x>3.93)
            {
                Destroy(gameObject);
            }
 
        }
        if(gameObject.tag=="LiserB")
        {
            ObjectBody.velocity = Vector2.up * ObjectSpeed;
        }


	}

    //void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
}
