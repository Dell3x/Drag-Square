using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum StateGame
{
    MainMenu,
    Play,
    Pause,
    Lose,
    Setting
}
public class GameState : MonoBehaviour
{
    public static event Action<StateGame> GameStateChanged;

    [SerializeField] private StateGame _stateGame;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject spawner;
    [SerializeField] private Text scoreLabel;

    private ScoreManager scoreManager;
    public StateGame StateCurrentGame => _stateGame;

    public int health;
    public int numOfHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void FixedUpdate()
    {
        if (health > numOfHealth)
        {
            health = numOfHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void ChangeState(StateGame state)
    {
        _stateGame = state;
        GameStateChanged?.Invoke(_stateGame);
    }

    public void LostHealth()
    {
        health--;

        if (health <= 0)
        {
            ShowLoseScreen();
        }
    }

    public void ShowLoseScreen()
    {
        losePanel.SetActive(true);
        ChangeState(StateGame.Lose);
        scoreLabel.text = "Your Score: " + scoreManager.score.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void PlayButton()
    {
        mainPanel.SetActive(false);
        ChangeState(StateGame.Play);
    }

    public void RestartButton()
    {
        losePanel.SetActive(false);
        ChangeState(StateGame.Play);
        health = 3;
        scoreManager.score = 0;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    #region Debug

    public StateGame newState;

    [ContextMenu("Change current state")]
    public void Change()
    {
        ChangeState(newState);
    }
    #endregion
}
