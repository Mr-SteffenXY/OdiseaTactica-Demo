using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void MissionComplete()
    {
        
        Debug.Log("Mission Complete");
    }

    public void LoadGame()
    {
        Debug.Log("Game Loaded");

        // Suponiendo que tienes una clase SceneChanger con un m�todo ChangeScene
        SceneChanger sceneChanger = new SceneChanger();
        sceneChanger.ChangeScene("Game");
    }

    public void SaveGame()
    {
        // Aqu� puedes agregar el c�digo para guardar tu juego
        // Por ejemplo, puedes usar PlayerPrefs, un archivo, una base de datos, etc.
        Debug.Log("Game Saved");
    }

    public void ExitGame()
    {
        // Si estamos en el editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si es una aplicaci�n construida
        Application.Quit();
#endif
    }
}
