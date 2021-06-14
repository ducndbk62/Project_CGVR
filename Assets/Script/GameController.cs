using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public Text txtPoint;

    private int currentPoint = 0;

    public AudioClip endSound;
    private AudioSource endAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPoint(int point)
    {
        currentPoint++;
        txtPoint.text = currentPoint.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        
        menu.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
