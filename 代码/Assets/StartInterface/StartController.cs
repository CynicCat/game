using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public GameObject Team;
    // Start is called before the first frame update
    void Start()
    {
        Team.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ProductionTeam()
    {
        Team.SetActive(true);
    }   
    
    public void GameExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
