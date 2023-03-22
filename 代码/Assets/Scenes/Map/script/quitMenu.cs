using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitMenu : MonoBehaviour
{
    public static bool GameIsPaused=false;
    public GameObject PauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");

    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
}
