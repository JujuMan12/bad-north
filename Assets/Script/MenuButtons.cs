using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private UIController uiController;
    [SerializeField] private SceneTransition sceneTransition;

    //[Header("Sound Effects")]
    //[SerializeField] private AudioSource ButtonSoundEffect;

    public void ResumeGame()
    {
        uiController.ChangePauseMenuState(false);
    }

    public void RestartGame()
    {
        //ButtonSoundEffect.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        //ButtonSoundEffect.Play();
        Application.Quit();
    }
}
