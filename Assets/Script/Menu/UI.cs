using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    [SerializeField]
    private GameObject PausePanel;

	// Use this for initialization
    public void LoadByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
}
