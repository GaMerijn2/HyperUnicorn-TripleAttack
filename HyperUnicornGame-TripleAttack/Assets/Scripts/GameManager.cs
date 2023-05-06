using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Other Variable's
    bool notPaused = true;


    // UI Variable's
    public GameObject pause_Screen;
    public GameObject bullet_UI;
    public Button resume_Game;
    public Button to_Main_Menu;

    public bool NotPaused
    {
        get { return notPaused; }
    }


    // Start is called before the first frame update
    void Start()
    {
        resume_Game.onClick.AddListener(ResumeGame);
        to_Main_Menu.onClick.AddListener(QuitToMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (notPaused)
        {
            Time.timeScale = 0;
            pause_Screen.SetActive(true);
            bullet_UI.SetActive(false);
            notPaused = false;
        } else if (!notPaused)
        {
            pause_Screen.SetActive(false);
            bullet_UI.SetActive(true);
            notPaused = true;
            Time.timeScale = 1;
        }

    }

    public void ResumeGame()
    {
        
        pause_Screen.SetActive(false);
        bullet_UI.SetActive(true);
        notPaused = true;
        Time.timeScale = 1;
    }

    public void QuitToMainMenu()
    {
        
        SceneManager.LoadScene(sceneBuildIndex: 0);
        Time.timeScale = 1;
    }


}
