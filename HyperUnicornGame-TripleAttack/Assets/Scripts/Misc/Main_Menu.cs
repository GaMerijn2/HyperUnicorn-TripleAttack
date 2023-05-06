using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{

    public Button play_game, how_To, quit;

    // Start is called before the first frame update
    void Start()
    {
        play_game.onClick.AddListener(PlayGame);
        how_To.onClick.AddListener(HowTo);
        quit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        ExitGame();
    }

    void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex:  1);
    }

    void HowTo()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void ExitGame()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }
    }
}
