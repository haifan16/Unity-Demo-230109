using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool _gameIsPause;
    private PlayerInputActions _playerInputActions;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemiesSpawner;
    [SerializeField] private GameObject _gameover;

    private void Awake() {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.PauseMenu.Enable();
    }

    private void Update() {
        if (_playerInputActions.PauseMenu.Pause.WasPressedThisFrame()) {
            if (_gameIsPause) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    private void Pause() {
        Time.timeScale = 0;
        _player.SetActive(false);

        _pauseMenu.SetActive(true);
        _enemiesSpawner.SetActive(false);
        _gameover.SetActive(false);
        _gameIsPause = true;
    }

    public void Resume() {
        _pauseMenu.SetActive(false);
        _enemiesSpawner.SetActive(true);
        _gameIsPause = false;
        
        Time.timeScale = 1;
        _player.SetActive(true);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
