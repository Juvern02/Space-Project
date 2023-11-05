using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCapsule : MonoBehaviour, IInteractable
{
    public float maxOxygen = 500f;
    public PlayerMovement playerMovement;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {

    playerMovement.IncreaseOxygen();
    Destroy(gameObject);
    Debug.Log("Opening capsule");
    return true;
  
    }

}
