using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public float playerSpeed;
    public Vector3 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 10;
        screenBounds = getScreenBounds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 getScreenBounds()
    {
        // Reference to camera set as MAIN
        Camera mainCamera = Camera.main;

        // Position for the center of screen
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }
}
