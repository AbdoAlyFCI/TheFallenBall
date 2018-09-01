using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour {
    private static Player instance;

    [SerializeField]
    private GameObject PausePanel;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
        set { Player.instance = value; }
    }

    [SerializeField]
    float MovmentSpeedV;

    [SerializeField]
    float MovmentSpeedH;

    [SerializeField]
    private List<string> damageSources;

    [SerializeField]
    private List<int> PlayerSpeed;

    [SerializeField]
    private List<float> TimeGap;

    [SerializeField]
    private List<float> GeneratorSecond;

    [SerializeField]
    private List<float> ScoreIncreasment;

    float increasment=0;
    int index = 0;

    [SerializeField]
    private int Heart;

    [SerializeField]
    private float immortalTime;

    [SerializeField]
    private float scorecalculate;

    [SerializeField]
    private GameObject GeneratorObject;

    private Generator GenratorScript;

    private bool immortal = false;

    public bool isDead=false;

    public bool RewardAd = false;

    float directionX;

    private Rigidbody2D PlayerBody;

    private SpriteRenderer PlayerRendeerer;

    [SerializeField]
    private GameObject UIElement;

    public GameObject UIElement1
    {
        get { return UIElement; }
        set { UIElement = value; }
    }
    [SerializeField]
    private GameObject UIElementResult;

    public GameObject UIElementResult1
    {
        get { return UIElementResult; }
        set { UIElementResult = value; }
    }
	// Use this for initialization
	void Start () {

        GenratorScript = GeneratorObject.GetComponent<Generator>();
        GenratorScript.spawnMin = GeneratorSecond[index];
        GenratorScript.spawnMax = GeneratorSecond[index];
        GameManger.Instance.Scoreincrease = 1;
        PlayerBody = GetComponent<Rigidbody2D>();
        PlayerRendeerer = GetComponent<SpriteRenderer>();
        StartCoroutine(ScoreUpdater());
        GameManger.Instance.Lives = Heart;
	}
	
	// Update is called once per frame
    void Update()
    {
       
        
            SpeedLevel();
            if (isDead == false)
            {
                input();
            }
        
    }

    void FixedUpdate()
    {
////#if UNITY_EDITOR_WIN
//        directionX = Input.GetAxisRaw("Horizontal");
//        PlayerBody.velocity = new Vector2(directionX * MovmentSpeedV, MovmentSpeedH);
//        //#endif

        //#if UNITY_ANDROID
      
        
            directionX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            PlayerBody.velocity = new Vector2(directionX * MovmentSpeedV, PlayerSpeed[index]);
        
        //#endif

   

    }



    void input()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
    }

    void SpeedLevel()
    {
        if (index < 7)
        {
            increasment += Time.deltaTime;
            //Debug.Log(increasment);
            if (increasment >= TimeGap[index])
            {
                index++;
                GenratorScript.spawnMin = GeneratorSecond[index];
                GenratorScript.spawnMax = GeneratorSecond[index];
                GameManger.Instance.Scoreincrease  ++;
                increasment = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (damageSources.Contains(other.tag))
        {
            StartCoroutine(TakeDamage());
        }
        if (other.gameObject.tag == "Coin")
        {
            GameManger.Instance.CollectedCoins1++;

            Destroy(other.gameObject);
        }
    }

    void OnDestroy()
    {
        Time.timeScale = 1;
    }

    void CalculateFinalResult()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(PlayerPrefs.GetInt("HighScore")<GameManger.Instance.CollectedScore1)
            {
                PlayerPrefs.SetInt("HighScore", GameManger.Instance.CollectedScore1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", GameManger.Instance.CollectedScore1);
        }
        if (PlayerPrefs.HasKey("TotalCoin"))
        {
            PlayerPrefs.SetInt("TotalCoin", (GameManger.Instance.CollectedCoins1+PlayerPrefs.GetInt("TotalCoin")));
        }
        else
        {
            PlayerPrefs.SetInt("TotalCoin", (GameManger.Instance.CollectedCoins1 + PlayerPrefs.GetInt("TotalCoin")));
        }
    }
    private IEnumerator ScoreUpdater()
    {
        while (true )
        {
            GameManger.Instance.CollectedScore1++;

            yield return new WaitForSeconds(ScoreIncreasment[index]); // I used .2 secs but you can update it as fast as you want
        }
    }



    public  IEnumerator TakeDamage()    //detect damage when happen
    {
        if (!immortal)
        {
            
            if (GameManger.Instance.Lives > 0)
            {


                GameManger.Instance.Lives--;
                if (GameManger.Instance.Lives == 0)
                {
                    CalculateFinalResult();
                    GameManger.Instance.FinalScore = GameManger.Instance.CollectedScore1;
                    GameManger.Instance.TotalCoin = PlayerPrefs.GetInt("TotalCoin");
                    Time.timeScale = 0;
                    if (RewardAd == false)
                    {                        
                        isDead = true;
                        UIElement.SetActive(true);
                    }
                    else
                    {
                 
                        
                        UIElementResult.SetActive(true);
                    }
                }

                if (GameManger.Instance.Lives !=0)
                {
                    immortal = true;
                    StartCoroutine(IndicateImmortal());
                    yield return new WaitForSeconds(immortalTime);
                    immortal = false;
                }
            }
            
        }

    }
    private IEnumerator IndicateImmortal()
    {
        while (immortal)
        {
            PlayerRendeerer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            PlayerRendeerer.enabled = true;
            yield return new WaitForSeconds(0.1f);

        }
    }
   
}
