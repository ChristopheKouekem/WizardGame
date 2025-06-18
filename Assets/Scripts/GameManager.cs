using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState { MainMenu, Play, Paused, GameOver }
    public GameState state;
    public static GameManager instance;

    private float timer;
    public float maxGameTime = 180f; // Set the maximum game time (e.g., 180 seconds)

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            state = GameState.Play;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (state == GameState.Play)
        {
            timer += Time.deltaTime;

            if (timer >= maxGameTime)
            {
                ReturnToMainMenu();
            }
        }
    }

    public void EnterGame()
    {
        state = GameState.Play;
        timer = 0f; // Reset the timer when entering the game
    }

    private void ReturnToMainMenu()
    {
        state = GameState.MainMenu;
        SceneManager.LoadScene("MainMenu"); // Ensure "MainMenu" is the name of your start screen scene
    }
}