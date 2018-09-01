using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning: MonoBehaviour
{
    [SerializeField]
    private float OnOff;

    BoxCollider2D WarningCollider;

    private SpriteRenderer WarningRendeerer;
    // Use this for initialization
    void Start()
    {
        WarningCollider = GetComponent<BoxCollider2D>();
        WarningRendeerer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "LiserB")
        {
            WarningRendeerer.enabled = true;
        }
    }

    void OnTriggerExit2D()
    {
        WarningRendeerer.enabled = false;
    }

    private IEnumerator IndicateAppearance()
    {
        WarningRendeerer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        WarningRendeerer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(OnOff);
    }
}
