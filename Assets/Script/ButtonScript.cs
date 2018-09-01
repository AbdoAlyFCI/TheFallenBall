using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using GoogleMobileAds;
using GoogleMobileAds.Api;

using System;
public class ButtonScript : MonoBehaviour
{


    //[SerializeField]
    //GameObject uie;

    //[SerializeField]
    //GameObject uil;

    public bool isclicked = false;

    private bool AdWatchedFull = false;

    private RewardBasedVideoAd rewardBasedVideo;
    public void Start()
    {
        //uie = GetComponent<GameObject>();
        //uil = GetComponent<GameObject>();
        //b1 = GetComponent<Button>();
        //b1.onClick.AddListener(GameOver);
#if UNITY_ANDROID
        string appId = "";
#elif UNITY_IPHONE
            string appId = "";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        // Get singleton reward based video ad reference.


        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        //// Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        this.RequestRewardBasedVideo();
    }
    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = "";
#elif UNITY_IPHONE
            string adUnitId = "";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    public void GameOver()
    {
        Debug.Log("woooooooooooooo");
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
        else
        {
            Debug.Log("eeeeeeeeeee");
        }
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        AdWatchedFull = true;
        

    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        //Player.Instance.UIElement1.SetActive(false);
        if (AdWatchedFull == true)
        {
            Player.Instance.RewardAd = true;
            Time.timeScale = 1;
            GameManger.Instance.Lives = 1;
            Player.Instance.isDead = true;
            Player.Instance.UIElement1.SetActive(false);
        }
        else
        {
            this.RequestRewardBasedVideo();
        }
    }

}
