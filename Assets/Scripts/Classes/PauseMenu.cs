using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeGame;
    [SerializeField] private Button quitGame;
    private void Awake()
    {
        gameController = GetComponent<GameController>();
        resumeGame.onClick.AddListener(() => ResumeGame());
        quitGame.onClick.AddListener(() => QuitGame());
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.isPaused)
        {
            pausePanel.SetActive(true);
        } else
        {
            pausePanel.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        gameController.TogglePause();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
