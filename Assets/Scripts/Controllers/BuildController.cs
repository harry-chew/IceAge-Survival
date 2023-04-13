using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildController : MonoBehaviour
{
    [SerializeField] private GameObject buildMenuPanel;
    [SerializeField] private List<Button> buildMenuItems;
    [SerializeField] private List<GameObject> constructItems;
    [SerializeField] private GameObject selectedItem;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform environment;

    [SerializeField] private GameObject currentPlaceableObject;
    [SerializeField] public bool isSelected;

    private float mouseWheelRotation;

    void Start()
    {
        selectedItem = null;
    }
    
    void Update()
    {
        SetBuildMenuActiveState();
        HandleNewObjectHotKey();

        if (currentPlaceableObject != null)
        {
            MoveCurrentPlaceableObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    private void SetBuildMenuActiveState()
    {
        if (Input.GetKeyUp(KeyCode.B) && !IsBuildMenuOpen())
        {
            buildMenuPanel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.B) && IsBuildMenuOpen())
        {
            buildMenuPanel.SetActive(false);
        }
    }

    private void RotateFromMouseWheel()
    {
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10.0f);
    }

    private void ReleaseIfClicked()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
            selectedItem = null;
            isSelected = false;
        }
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 50f, groundLayer))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }

    }

    private void HandleNewObjectHotKey()
    {

            if(currentPlaceableObject == null && !isSelected)
            {
                currentPlaceableObject = Instantiate(selectedItem);
                isSelected = true;
            }
    }

    private void FixedUpdate()
    {

        /*
        if (!IsBuildMenuOpen() && selectedItem != null)
        {
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, groundLayer))
            {
                GameObject objToSpawn = Instantiate(selectedItem, hit.point, Quaternion.identity, environment);
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }

        }
        */
    }

    public bool IsBuildMenuOpen()
    {
        return buildMenuPanel.activeSelf;
    }

    public void ConstructCampFire()
    {
        Debug.Log("Camp fire clicked");
        buildMenuPanel.SetActive(false);
        SelectItem(constructItems[0]);
    }

    public void ConstructItem(GameObject item)
    {
        buildMenuPanel.SetActive(false);
        SelectItem(item);
    }
    private void SelectItem(GameObject selection)
    {
        selectedItem = selection;
    }
}
