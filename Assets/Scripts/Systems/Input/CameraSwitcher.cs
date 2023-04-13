using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera tacticalCamera;

    private void Start()
    {
        mainCamera.gameObject.SetActive(true);
        tacticalCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.M))
        {
            SwitchToTacticalCamera();
        }
    }

    private void SwitchToTacticalCamera()
    {
        if(tacticalCamera.gameObject.activeSelf)
        {
            mainCamera.gameObject.SetActive(true);
            tacticalCamera.gameObject.SetActive(false);
        } 
        else
        {
            mainCamera.gameObject.SetActive(false);
            tacticalCamera.gameObject.SetActive(true);
        }
    }
}
