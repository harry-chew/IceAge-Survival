using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private AudioListener audioListener;
    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameController();
            }

            return _instance;
        }

        private set
        {
            _instance = value;
        }
    }

    public bool isPaused;
    public float SimulationSpeed;

    private void Start()
    {
        SimulationSpeed = 1.0f;
        isPaused = false;
    }


    private void Update()
    {
        Time.timeScale = SimulationSpeed;

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            SimulationSpeed = 1.0f;
            isPaused = false;
            AudioListener.pause = false;
            Debug.Log("UnPause");
        } 
        else if(!isPaused)
        {
            SimulationSpeed = 0.0f;
            isPaused = true;
            AudioListener.pause = true;
            Debug.Log("Paused");
        }
    }
}
