using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {



    [SerializeField]
    private Transform playerPostion; 
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(0, playerPostion.position.y-1.8f, -10);
	}


}
