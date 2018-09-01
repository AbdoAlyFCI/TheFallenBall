using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour {



    private static GameManger instance;

    [SerializeField]
    private GameObject CoinPrefab;

    [SerializeField]
    private Text CoinText;

    private int CollectedCoins;

    




    public int CollectedCoins1
    {
        get { return CollectedCoins; }
        set {
            CoinText.text = value.ToString();
            CollectedCoins = value; 
        }
    }

    public GameObject CoinPrefab1
    {
        get { return CoinPrefab; }
    }




    [SerializeField]
    private Text ScoreText;

    private int CollectedScore;

    public int CollectedScore1
    {
        get { return CollectedScore; }
        set
        {
            ScoreText.text = value.ToString();
            CollectedScore = value;
        }
    }


    [SerializeField]
    private Text LivesText;

    private int lives;

    public int Lives
    {
        get { return lives; }
        set {
            LivesText.text = value.ToString();
            lives = value; 
        }
    }

    [SerializeField]
    private Text IncreaseText;

    private int scoreincrease;

    public int Scoreincrease
    {
        get { return scoreincrease; }
        set {
            IncreaseText.text = value.ToString();
            scoreincrease = value;
        }
    }

    [SerializeField]
    private Text FinalScoreText;

    private int finalScore;

    public int FinalScore
    {
        get { return finalScore; }
        set {
            FinalScoreText.text = value.ToString();
            finalScore = value;
        }
    }

    [SerializeField]
    public Text TotalCoinText;

    private int totalCoin;

    public int TotalCoin
    {
        get { return totalCoin; }
        set { 
            TotalCoinText.text = value.ToString();
            totalCoin = value;
        }
    }

 


    public static GameManger Instance
    {

        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManger>();
            }
            return instance;
        }

    }
	// Use this for initialization

}
