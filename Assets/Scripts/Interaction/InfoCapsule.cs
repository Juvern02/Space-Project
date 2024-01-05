using System;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class InfoCapsule : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public GameObject playerCam;
    public GameObject cutSceneCam;
    public TextMeshPro[] textArray;
    private int currentTextIndex = 0;
    public GameObject[] timelines;
    private int currentTimeLineIndex = 0;

    public void Start()
    {
        for (int i = 0; i < textArray.Length; i++)
        {
            textArray[i].gameObject.SetActive(false);
        }
        timelines[currentTimeLineIndex].SetActive(false);
        cutSceneCam.SetActive(false);
    }

    public bool Interact(Interactor interactor)
    {
        DisplayCurrentText();
        currentTextIndex++;

        if (currentTextIndex >= textArray.Length)
        {
            gameObject.SetActive(false);
        }

        return true;
    }

    private void DisplayCurrentText()
    {
        if (currentTextIndex == 0 && currentTimeLineIndex < timelines.Length)
        {
            playerCam.SetActive(false);
            cutSceneCam.SetActive(true);
            playerCam.SetActive(true);
            timelines[currentTimeLineIndex].SetActive(true);
            Invoke("SwitchtoPlayerCam", 5f);

        }
        if (currentTextIndex >= 0 && currentTextIndex < textArray.Length)
        {
            for (int i = 0; i < textArray.Length; i++)
            {
                if (i == currentTextIndex)
                {
                    textArray[i].gameObject.SetActive(true);
                }
                else
                {
                    textArray[i].gameObject.SetActive(false);
                }
            }
        }
    }
    
    private void SwitchtoPlayerCam()
    {
        cutSceneCam.SetActive(false);
        timelines[currentTimeLineIndex].SetActive(false);
        playerCam.SetActive(true);
    }
}