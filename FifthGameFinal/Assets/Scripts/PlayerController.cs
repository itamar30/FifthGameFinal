using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform laserSpawn;
    public GameObject laserPrefub;
    float maxWidth;
    float maxHeight;
    // Start is called before the first frame update

    void Start()
    {

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0);
        Vector3 targetWidth = Camera.main.ScreenToViewportPoint(upperCorner);

        float playerWidth = GetComponent<Renderer>().bounds.extents.x;
        float playerHeight = GetComponent<Renderer>().bounds.extents.y;



        maxWidth = targetWidth.x + (2.5f *playerWidth);
        maxHeight = targetWidth.y + (2.5f * playerHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire();
        }
        updetaPosition();
    }

    void fire()
    {
        Instantiate(laserPrefub, laserSpawn.position, Quaternion.identity);
    }



    void updetaPosition()
    {
        Vector3 rawPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, rawPosition.y, 0.0f);

        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        float targetHeight = Mathf.Clamp(targetPosition.y, -maxHeight, maxHeight);
        targetPosition = new Vector3(targetWidth, targetHeight, targetPosition.z);
        transform.position = targetPosition;


    }
}
