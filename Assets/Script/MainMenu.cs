using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject UI_MainMenu;

    public GameObject UI_Setting;
    public GameObject UI_About;
    public Slider slider;

    public void ToGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        UI_About.SetActive(false);
        UI_Setting.SetActive(false);

        UI_MainMenu.SetActive(true);
    }

    public void Setting()
    {
        UI_MainMenu.SetActive(false);
        UI_Setting.SetActive(true);
    }

    public void About()
    {
        UI_MainMenu.SetActive(false);
        UI_About.SetActive(true);
    }

    public void SettingAudio()
    {
        AudioListener.volume = slider.value;
    }
}