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
    //click and move middle mouse to rotate the camera around
    //it will be clamped to a certain point in space to rotate around

    //scroll wheel to zoom in and out 
    //will be clamped to not allow it to go through the floor or zoom out to space :P

    //space bar will centre the camera over all survivors


    // Start is called before the first frame update

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float moveSpeed = 5.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotate();
        HandleMovement();
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

            cameraRotatePoint.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            cameraMovePoint.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }
    }

    private void HandleMovement()
    {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");

        cameraMovePoint.transform.Translate(new Vector3(mh * moveSpeed * Time.deltaTime, 0, mv * moveSpeed * Time.deltaTime));
    }
}
