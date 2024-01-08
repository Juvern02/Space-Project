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

                PlayerPrefs.SetInt("barrierKey", PlayerPrefs.GetInt("barrierKey") + 1);
                Debug.Log(PlayerPrefs.GetInt("barrierKey"));

                /*if (PuzzleGame == 0)
                {
                    SceneManagerScript sceneManager = new SceneManagerScript();
                    sceneManager.LoadScene("Puzzle");
                }
                else if(PuzzleGame == 1)
                {
                    SceneManagerScript sceneManager = new SceneManagerScript();
                    sceneManager.LoadScene("Puzzle 2");
                }
                else if (PuzzleGame == 2)
                {
                    SceneManagerScript sceneManager = new SceneManagerScript();
                    sceneManager.LoadScene("Puzzle 3");
                }
                else if (PuzzleGame == 3)
                {
                    SceneManagerScript sceneManager = new SceneManagerScript();
                    sceneManager.LoadScene("Puzzle 4");
                }*/

                return true;
            }
            
        }

        return false;
    }
}
