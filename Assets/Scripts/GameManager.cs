using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameover;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemiesSpawner;
    [SerializeField] private int _score;
    [SerializeField] private Text _scoreText;
    [HideInInspector] public bool _isPlayerAlive;

    private void Awake()
    {
        _score= 0;
        _scoreText.text = "Score: 0";
        _isPlayerAlive = true;
    }

    private void FixedUpdate()
    {
        if (_player.GetComponent<PlayerHealth>()._health <= 0)
        {
            _isPlayerAlive = false;
            Gameover();
        }
    }
    
    public void Gameover()
    {
        _enemiesSpawner.SetActive(false);
        _gameover.SetActive(true);
        _scoreText.text.Remove(0);
        Pause();
    }

    public void Restart()
    {
        _gameover.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private void Pause()
    {
        Time.timeScale = 0;
        _player.SetActive(false);
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = "Score: " + _score.ToString();
    }
}
