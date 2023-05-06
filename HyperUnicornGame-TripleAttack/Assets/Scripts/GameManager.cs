using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Other Variable's



    // UI Variable's
    public GameObject pause_Screen;
    public GameObject bullet_UI;
    public Button resume_Game;
    public Button to_Main_Menu;

    // Start is called before the first frame update
    void Start()
    {
        resume_Game.onClick.AddListener(ResumeGame);
        to_Main_Menu.onClick.AddListener(QuitToMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePauseMenu()
    {
        Time.timeScale = 0;
        pause_Screen.SetActive(true);
        bullet_UI.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pause_Screen.SetActive(false);
        bullet_UI.SetActive(true);
    }

    public void QuitToMainMenu()
    {

    }

}
