using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TakePhoto : MonoBehaviour
{
    public GameObject PhotoCaptureCanvas;
    public float displayTime = 0.3f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ScreenCapture.CaptureScreenshot("screenshot-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", 4);
            Invoke("TextDisplay", displayTime);
        }
    }

    void TextDisplay()
    {
        PhotoCaptureCanvas.SetActive(true);
        Invoke("DisableCanvas", displayTime);
    }

    void DisableCanvas()
    {
        PhotoCaptureCanvas.SetActive(false);
    }
}