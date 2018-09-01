using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {


    [SerializeField]
    protected GameObject[] Objects;

    [SerializeField]
    protected Transform[] Points;

    [SerializeField]
    public float spawnMin;  
    [SerializeField]
    public float spawnMax;

    private int select;

    protected Vector3 PlaceThatWasFound;
 	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
        //Start();
	}
    protected virtual void Spawn()
    {

        select = Random.Range(0, Points.Length);
        if(gameObject.tag=="LiserC"||gameObject.tag=="LiserBC")
        {
             PlaceThatWasFound = new Vector3(Points[select].position.x, Points[select].position.y, 0);
             if (gameObject.tag == "LiserBC")
             {
                 select = 0;
             }
        }
        else
        {
            PlaceThatWasFound = transform.position;
        }
        
        Instantiate(Objects[select],PlaceThatWasFound,Quaternion.identity);
        Invoke("Spawn", UnityEngine.Random.Range(spawnMin, spawnMax));
    }





}
