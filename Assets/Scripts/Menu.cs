using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menumanager;

    void Start()
    {
	MainMenuButton();
    }

    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Forest");
    }

    // Update is called once per frame
    public void MainMenuButton()
    {
        menumanager.SetActive(true);
    }

    public void QuitButton()
    {
	Application.Quit();
    }
}
