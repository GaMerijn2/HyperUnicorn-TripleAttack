using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Other Variable's
    bool notPaused = true;

    int powerLevel;
    public Elevator elevator;
    public GameObject level_2, level_3;
    // UI Variable's
    public GameObject pause_Screen;
    public GameObject bullet_UI;
    public Button resume_Game;
    public Button to_Main_Menu;
    public Button to_main, goToMainMenu;

    public TMP_Text powerLevelUI;

    public GameObject gameOver;
    public GameObject gameEnd;

    public bool NotPaused
    {
        get { return notPaused; }
    }

    // Start is called before the first frame update
    void Start()
    {
        resume_Game.onClick.AddListener(ResumeGame);
        to_Main_Menu.onClick.AddListener(QuitToMainMenu);
        to_main.onClick.AddListener(QuitToMainMenu);
        goToMainMenu.onClick.AddListener(QuitToMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
        PowerLevelUI();
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

    public void PowerLevelUp()
    {
        powerLevel++;
    }

    void PowerLevelUI()
    {
        switch (powerLevel)
        {
            case 0:
                powerLevelUI.text = "powerlevel: 0";
                break;
            case 1:
                powerLevelUI.text = "powerlevel: 1";
                break;
            case 2:
                powerLevelUI.text = "powerlevel: 2";
                level_2.SetActive(true);
                break;
            case 3:
                powerLevelUI.text = "powerlevel: 3";
                level_3.SetActive(true);
                break;
            case 4:
                powerLevelUI.text = "powerlevel: 4";
                break;
            case 5:
                powerLevelUI.text = "powerlevel: 5";
                elevator.OpenElevator();
                break;
            default:
                break;
        }
    }

    public void GameEnd()
    {
        gameEnd.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
