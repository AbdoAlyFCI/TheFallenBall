using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSlider : MonoBehaviour {

    [SerializeField]
    private Sprite[] HowToPlay;

    [SerializeField]
    private Image view;

    [SerializeField]
    private Button Left;

    [SerializeField]
    private Button Right;

    int index = 0;
	// Use this for initialization
	void Start () {
        view.sprite = HowToPlay[index];
        Left.onClick.AddListener(LeftClick);
        Right.onClick.AddListener(RightClick);
	}

    public void LeftClick()
    {

        if(index >0)
        {
            index--;
            Debug.Log(index);
            view.sprite = HowToPlay[index];
        }
    }

    public void RightClick()
    {

        if (index < 4)
        {
            
            index++;
            Debug.Log(index);
            view.sprite = HowToPlay[index];
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

    void OnDisable()
    {
        MManger.Instance.exit = true;
    }

    void OnEnable()
    {
        MManger.Instance.exit = false;
    }
}
