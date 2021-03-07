using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    private int unlockedLevel = 0;
    private static int currentLevel;

    public static string[] levels = {"LevelOneScene", "LevelTwoScene",
    "LevelThreeScene", "LevelFourScene", "LevelFiveScene"};

    public static int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("UnlockedLevel"))
        {
            unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        }
        else
        {
            PlayerPrefs.SetInt("UnlockedLevel", 1);
        }
        showLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showLevel()
    {
        for(int i=0; i < PlayerPrefs.GetInt("UnlockedLevel"); i++)
        {
            levelButtons[i].gameObject.SetActive(true);
        }
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("LevelOneScene");
        CurrentLevel = 1;
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("LevelTwoScene");
        CurrentLevel = 2;

    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("LevelThreeScene");
        CurrentLevel = 3;

    }

    public void GoToLevel4()
    {
        SceneManager.LoadScene("LevelFourScene");
        CurrentLevel = 4;

    }

    public void GoToLevel5()
    {
        SceneManager.LoadScene("LevelFiveScene");
        CurrentLevel = 5;

    }
}
