using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneManager : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("LevelMapScene");
    }
    public void AboutPanel()
    {
        panel.gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.gameObject.SetActive(false);

    }
}
