using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text clickText;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickText.enabled = false;
        }
    }
    
    public static void GoOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public static void GoToLevel()
    {

        SceneManager.LoadScene("LevelMapScene");

    }
    public static void Restart()
    {
        SceneManager.LoadScene(LevelManager.levels[(LevelManager.CurrentLevel) - 1]);
    }

    public void PauseGame()
    {
        if (paused)
        {
            PlayerController.PauceGame(paused);
            paused = false;
            Time.timeScale = 0;
        }
        else
        {
            PlayerController.PauceGame(paused);
            paused = true;
            Time.timeScale = 1;
        }
    }
}
