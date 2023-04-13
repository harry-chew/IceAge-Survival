using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SimulationSpeedSlider : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private Slider simulationSpeedSlider;
    [SerializeField]
    private TMP_Text simulationSpeedText;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        simulationSpeedSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.isPaused)
        {
            gameController.SimulationSpeed = simulationSpeedSlider.value;
        }
        simulationSpeedText.text = gameController.SimulationSpeed + "x";
    }
}
