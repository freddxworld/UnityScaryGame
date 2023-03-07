using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlayerLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform playerBody;

    private float xRotation = 0f;
    public Canvas ui;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact();
        }

        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 3);
        if (hit && hitInfo.transform.gameObject.tag == "Interactable")
        {
            ui.enabled = true;
        }
        else
        {
            ui.enabled = false;
        }
    }

    private void interact()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 3);
        ui.enabled = true;
        if (hit && hitInfo.transform.gameObject.tag == "Interactable")
        {
            hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material.color = new Color(.5f, .3f, .3f);
            Debug.Log("hit");
        }
    }
}
