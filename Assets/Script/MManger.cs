using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MManger : MonoBehaviour {
    private static MManger instance;

    public bool exit = true;

    public static MManger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MManger>();
            }
            return instance;
        }
        set { MManger.instance = value; }
    }

    [SerializeField]
    private Text highscore;

    [SerializeField]
    private Text FullCoin;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore.text = (PlayerPrefs.GetInt("HighScore")).ToString();
        }
        if (PlayerPrefs.HasKey("TotalCoin"))
        {
            FullCoin.text = (PlayerPrefs.GetInt("TotalCoin")).ToString();
        }
    }

    void Update()
    {
        input();
    }
    void input()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) &&exit==true)
        {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
