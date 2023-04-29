using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Other Variable's

    // UI Variable's
    public GameObject Pause_Screen;
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

    }

    public void ResumeGame()
    {

    }

    public void QuitToMainMenu()
    {

    }

}
