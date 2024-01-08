using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FixItemInteract : MonoBehaviour, IInteractable
{
    public string itemName;
    public int PuzzleGame;
    [SerializeField] private string _prompt;
    public SceneManagerScript sceneManager;
    public string InteractionPrompt => _prompt;
    private void Start()
    {
        PlayerPrefs.SetInt("barrierKey", 0);
    }
    public bool Interact(Interactor interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory != null)
        {
            // Call the method in the Inventory script to fix the item
            if (inventory.FixItem(itemName))
            {
                Canvas canvas = GetComponentInChildren<Canvas>();

                TextMeshProUGUI textComponent = canvas.GetComponentInChildren<TextMeshProUGUI>();

                Image imageComponent = canvas.transform.GetChild(1).GetComponent<Image>();

                textComponent.gameObject.SetActive(false);
                imageComponent.gameObject.SetActive(true);

                PlayerPrefs.SetInt("barrierKey", PuzzleGame + 1);
                Debug.Log(PlayerPrefs.GetInt("barrierKey"));

                if (inventory.GetItemsFixed() == 4)
                {
                    ActivateProjectorStars();
                }

                // if (PuzzleGame == 0)
                // {
                //     sceneManager.LoadScene("Puzzle");
                // }
                // else if (PuzzleGame == 1)
                // {
                //     sceneManager.LoadScene("Puzzle 2");
                // }
                // else if (PuzzleGame == 2)
                // {
                //     sceneManager.LoadScene("Puzzle 3");
                // }
                // else if (PuzzleGame == 3)
                // {
                //     sceneManager.LoadScene("Puzzle 4");
                // }

                return true;
            }
            
        }

        return false;
    }

    private void ActivateProjectorStars()
    {
        GameObject projectorStars = GameObject.Find("projector stars");

        if (projectorStars != null)
        {
            Transform firstChild = projectorStars.transform.GetChild(0);

            if (firstChild != null)
            {
                firstChild.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Could not find 'projector stars' object.");
        }
    }
}
