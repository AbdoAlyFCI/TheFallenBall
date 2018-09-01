using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGenerator : Generator {


    float x;
	// Use this for initialization
	void Start () {
        
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void Spawn()
    {
        float random = UnityEngine.Random.Range(-1.9f, 2.12f);
        transform.position = new Vector3(random, transform.position.y, transform.position.z);
        int num = UnityEngine.Random.Range(1, 20);
        
        for (int i = 0; i < num; i++)
        {
            //PlaceThatWasFound = PutPlace();
            transform.position = PutPlace();
            Instantiate(Objects[0], transform.position, Quaternion.identity);
        }
        Invoke("Spawn", UnityEngine.Random.Range(spawnMin, spawnMax));
    }
    private Vector3 PutPlace()
    {
        int selectdirection = UnityEngine.Random.Range(1, 3);
        float x = gameObject.transform.position.x;
        if(selectdirection==1)
        {
            x -= .5f;
            if(testborder(x)==false)
            {
                selectdirection = 3;
            }
            
        }
        if(selectdirection==2)
        {
            x += .5f;
            if (testborder(x)==false)
            {
                selectdirection = 3;
            }

        }
        if(selectdirection==3)
        {
             x = PlaceThatWasFound.x;
        }

        return new Vector3(x, gameObject.transform.position.y-.5f, 0);
    }
    private bool testborder( float i)
    {

        if ((i > 2.12f) || (i < -1.9f))
        {
            return false;
        }

        else
        {
            return true;
        }

    }
}
