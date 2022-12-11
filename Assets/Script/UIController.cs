using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [HideInInspector] public bool pauseMenuIsShown;

    [Header("UI Elements")]
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        Time.timeScale = 1f;
        sceneTransition.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ChangePauseMenuState(!pauseMenuIsShown);
        }
    }

    public void ChangePauseMenuState(bool state)
    {
        pauseMenuIsShown = state;
        pauseMenu.SetActive(state);

        if (state)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
