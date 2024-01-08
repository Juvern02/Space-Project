using System;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    public GameObject PhotoCaptureCanvas;
    public float displayTime = 0.3f;
    public string screenshotFolder = "Screenshots";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            CaptureScreenshot();
        }
    }

    void CaptureScreenshot()
    {
        string folderPath = Application.dataPath + "/" + screenshotFolder;
        if (!System.IO.Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath);
        }

        string fileName = "screenshot-" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
        string filePath = System.IO.Path.Combine(folderPath, fileName);
        ScreenCapture.CaptureScreenshot(filePath, 4);

        Invoke("TextDisplay", displayTime);
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
