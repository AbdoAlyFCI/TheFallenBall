using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorControl : MonoBehaviour {

    [SerializeField]
    GameObject GenratorObjects1;

    [SerializeField]
    GameObject GenratorObjects2;

    private Generator scripts1;
    private Generator scripts2;

    bool up = true;

    int t;
	// Use this for initialization
	void Start () {
      //scripts = new Generator[GenratorObjects.Length];
      //for (int i = 0; i < GenratorObjects.Length; i++)
      //{
          //scripts[i] = GenratorObjects[i].GetComponent<Generator>();
        scripts1 = GenratorObjects1.GetComponent<Generator>();
        scripts2 = GenratorObjects2.GetComponent<Generator>();
      //}
	}
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(Example());
        if (up == true)
        {
            int i = UnityEngine.Random.Range(0, 2);
            if (i == 0)
            {
                //Debug.Log(scripts1.Key1);
                GenratorObjects1.SetActive(true);
  
      
                GenratorObjects2.SetActive(false);
                //StartCoroutine(Example()); 
                //scripts2.Key1 = false;
            }
            if (i == 1)
            {
                GenratorObjects2.SetActive(true);
         
            
                GenratorObjects1.SetActive(false);
                

            }
        }
        StartCoroutine(Example(5));
      
	}
    IEnumerator Example(int time)
    {
        //print(Time.time);
        up = false;
        yield return new WaitForSeconds(5);
        up = true;
        //print(Time.time);
    }

 
}
