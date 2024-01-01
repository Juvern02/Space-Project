using System;
using TMPro;
using UnityEngine;

public class InfoCapsule : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public TextMeshPro[] textArray;
    private int currentTextIndex = 0;

    public void Start()
    {
        for (int i = 0; i < textArray.Length; i++)
        {
            textArray[i].gameObject.SetActive(false);
        }
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
}