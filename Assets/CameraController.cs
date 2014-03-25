using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{


    public Camera maincamera;
    public Camera secondcamera;

    
    private Camera[] cameras;
    private int currentCameraIndex = 0;
    private Camera currentCamera;

    // Use this for initialization
    void Start()
    {
        maincamera = GameObject.Find("maincamera").camera;
        secondcamera = GameObject.Find("secondcamera").camera;

        cameras = new Camera[] { maincamera, secondcamera };//this is the array of cameras
        currentCamera = maincamera; //When the program start the main camera is selected as the default camera
        ChangeView();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            currentCameraIndex++;
            if (currentCameraIndex > cameras.Length - 1)
                currentCameraIndex = 0;
            ChangeView();
        }
    }

    void ChangeView()
    {
        currentCamera.enabled = false;
        currentCamera = cameras[currentCameraIndex];
        currentCamera.enabled = true;
    }
}
