using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipDoorInteract : MonoBehaviour, IInteractable
{

    public string sceneName;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public SceneManagerScript sceneManagerScript;

    public bool Interact(Interactor interactor)
    {
    sceneManagerScript.LoadScene(sceneName);

    Debug.Log("Opening Door");
    return true;
  
    }
}
