using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject _mainMenu;

    public void StartGame() {
        _mainMenu.SetActive(false);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;
    }

    public void LoadOptions() {
        Debug.Log("Options Loaded");
    }

    public void QuitGame() {
        Debug.Log("Game Quit");
        Application.Quit();
    }

}
