using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlayerLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform playerBody;
    public Canvas ui;
    private float xRotation = 0f;
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

        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 2);
        
        if (hit && hitInfo.transform.gameObject.tag == "interactable")
        {
            ui.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                interact(hitInfo);
                
            }
        }
        else
        {
            ui.enabled = false;
        }
    }

    private void interact(RaycastHit hitInfo)
    {
        hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material.color = new Color(.3f, .3f, .6f);
    }
}
