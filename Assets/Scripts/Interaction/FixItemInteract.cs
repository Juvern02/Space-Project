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
    private SceneManagerScript sceneManager;
    public string InteractionPrompt => _prompt;
    private void Start()
    {
        PlayerPrefs.SetInt("barrierKey", 0);
        sceneManager = FindFirstObjectByType<SceneManagerScript>();
        if (sceneManager == null)
        {
            Debug.LogError("SceneManagerScript not found in the scene. Make sure to assign it in the Inspector.");
        }
    }
    public bool Interact(Interactor interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory != null)
        {
            // Call the method in the Inventory script to fix the item
            if (inventory.FixItem(itemName))
            {
                if (PuzzleGame == 0)
                {
                    sceneManager.LoadScene("Puzzle");
                }
                else if (PuzzleGame == 1)
                {
                    sceneManager.LoadScene("Puzzle 2");
                }
                else if (PuzzleGame == 2)
                {
                    sceneManager.LoadScene("Puzzle 3");
                }
                else if (PuzzleGame == 3)
                {
                    sceneManager.LoadScene("Puzzle 4");
                }
                Canvas canvas = GetComponentInChildren<Canvas>();

                TextMeshProUGUI textComponent = canvas.GetComponentInChildren<TextMeshProUGUI>();

                Image imageComponent = canvas.transform.GetChild(1).GetComponent<Image>();

                textComponent.gameObject.SetActive(false);
                imageComponent.gameObject.SetActive(true);

                PlayerPrefs.SetInt("barrierKey", PuzzleGame + 1);
                Debug.Log(PlayerPrefs.GetInt("barrierKey"));

                return true;
            }
            
        }

        return false;
    }

    
}
