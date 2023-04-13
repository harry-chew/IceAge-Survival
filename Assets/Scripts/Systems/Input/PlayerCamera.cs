using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField]
    private Vector2 mousePostition;
    [SerializeField]
    private Vector2 initialMousePostition;
    [SerializeField]
    private Vector3 cameraRotateVector;
    [SerializeField]
    private Transform cameraRotatePoint;
    [SerializeField]
    private Transform cameraMovePoint;

    public Vector2 moveDirection;

    [SerializeField]
    private BuildController buildController;

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float moveSpeed = 5.0f;
    public float zoomSpeed = 2.0f;
    public float maxZoom = 40f;
    public float minZoom = 5f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    public float minY = 10f;
    public float maxY = 90f;

    public int pixelBorderBuffer = 15;

    [SerializeField] private GameObject[] tribeMembers;
    [SerializeField] private Transform[] posOfTribeMembers;

    void Update()
    {
        HandleRotate();
        HandleMovement();
        HandleZoom();
        HandleCentre();
    }

    //this is not finished
    private void HandleCentre()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            tribeMembers = GameObject.FindGameObjectsWithTag("TribeMember");
            StartCoroutine(Loading(0.3f));
        }
    }

    //honestly cant remember why i did this...
    private IEnumerator Loading(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < tribeMembers.Length; i++)
        {
            posOfTribeMembers[i] = tribeMembers[i].transform;
        }
    }
    private void HandleRotate()
    {
        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            initialMousePostition = Input.mousePosition;
        }
        if(Input.GetKey(KeyCode.Mouse2))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, minY, maxY);
            cameraRotatePoint.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            cameraMovePoint.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }
    }

    private void HandleMovement()
    {
        if(!Input.GetKey(KeyCode.Mouse2))
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            moveDirection = new Vector2(moveHorizontal, moveVertical);

            cameraMovePoint.transform.Translate(new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0, moveVertical * moveSpeed * Time.deltaTime));
            mousePostition = Input.mousePosition;
            
            
            if (mousePostition.x <= pixelBorderBuffer)
                cameraMovePoint.transform.Translate(new Vector3(-1 * moveSpeed * Time.deltaTime, 0, 0));

            if (mousePostition.x >= Screen.width - pixelBorderBuffer)
                cameraMovePoint.transform.Translate(new Vector3(1 * moveSpeed * Time.deltaTime, 0, 0));

            if (mousePostition.y <= pixelBorderBuffer)
                cameraMovePoint.transform.Translate(new Vector3(0, 0, -1 * moveSpeed * Time.deltaTime));

            if (mousePostition.y >= Screen.height - pixelBorderBuffer)
                cameraMovePoint.transform.Translate(new Vector3(0, 0, 1 * moveSpeed * Time.deltaTime));
            
        }
    }

    private void HandleZoom()
    {
        if (buildController.isSelected) return;

        float height = gameObject.transform.position.y;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0 && height < maxZoom)
            gameObject.transform.Translate(Vector3.back * zoomSpeed, Space.Self);

        if (scroll > 0 && height > minZoom)
            gameObject.transform.Translate(Vector3.forward * zoomSpeed, Space.Self);
    }
}
