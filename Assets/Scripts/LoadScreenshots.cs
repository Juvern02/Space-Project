using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreenshots : MonoBehaviour
{
    public RawImage screenshotDisplayPrefab;
    public Transform screenshotContainer;
    public string screenshotFolder = "Screenshots";
    public float spacing = 5f;
    public float startingY = -5f;
    public float scaleFactor = 0.7f;

    void Start()
    {
        LoadAllScreenshots();
    }

    void LoadAllScreenshots()
    {
        string folderPath = Application.dataPath + "/" + screenshotFolder;

        if (Directory.Exists(folderPath))
        {
            string[] screenshotPaths = Directory.GetFiles(folderPath, "*.png");

            if (screenshotPaths.Length > 0)
            {
                // Sort the screenshot paths by creation time (assuming they are named based on timestamp)
                System.Array.Sort(screenshotPaths, (a, b) => File.GetCreationTime(a).CompareTo(File.GetCreationTime(b)));

                // Calculate total height based on the number of screenshots, spacing, and canvas dimensions
                float totalHeight = (screenshotDisplayPrefab.rectTransform.sizeDelta.y + spacing) * screenshotPaths.Length;

                // Calculate number of columns based on canvas dimensions
                int columns = Mathf.CeilToInt(totalHeight / screenshotContainer.GetComponent<RectTransform>().sizeDelta.y);

                // Load and display all screenshots
                for (int i = 0; i < screenshotPaths.Length; i++)
                {
                    DisplayScreenshot(screenshotPaths[i], i, totalHeight, columns);
                }
            }
            else
            {
                Debug.LogWarning("No screenshots found in the folder: " + folderPath);
            }
        }
        else
        {
            Debug.LogError("Screenshot folder not found: " + folderPath);
        }
    }

    void DisplayScreenshot(string imagePath, int index, float totalHeight, int columns)
    {
        // Load the screenshot as a texture
        byte[] fileData = File.ReadAllBytes(imagePath);
        Texture2D screenshotTexture = new Texture2D(2, 2);
        screenshotTexture.LoadImage(fileData);

        // Create a new RawImage to display the screenshot
        RawImage screenshotDisplay = Instantiate(screenshotDisplayPrefab, screenshotContainer);

        // Calculate the aspect ratio of the screenshot
        float aspectRatio = (float)screenshotTexture.width / screenshotTexture.height;

        // Calculate the scaled size
        float maxWidth = screenshotContainer.GetComponent<RectTransform>().sizeDelta.x / columns - spacing;
        float maxHeight = screenshotContainer.GetComponent<RectTransform>().sizeDelta.y / (totalHeight / screenshotContainer.GetComponent<RectTransform>().sizeDelta.y) - spacing;

        float scaledWidth = Mathf.Min(maxWidth, aspectRatio * maxHeight * scaleFactor);
        float scaledHeight = scaledWidth / aspectRatio;

        // Set the texture and scale
        screenshotDisplay.texture = screenshotTexture;
        screenshotDisplay.rectTransform.sizeDelta = new Vector2(scaledWidth, scaledHeight);

        // Calculate position based on the total height, index, spacing, and number of columns
        float yOffset = startingY - (index % columns) * (scaledHeight + spacing);
        float xOffset = Mathf.Floor(index / columns) * (maxWidth + spacing);

        screenshotDisplay.rectTransform.anchoredPosition = new Vector2(xOffset, yOffset);
    }
}
