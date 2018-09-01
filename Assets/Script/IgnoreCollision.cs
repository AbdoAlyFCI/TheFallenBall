using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ignore object
public class IgnoreCollision : MonoBehaviour {

    [SerializeField]
    private Collider2D other;
	// Use this for initialization
	void Awake () {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, true);
	}
	
	// Update is called once per frame

}
