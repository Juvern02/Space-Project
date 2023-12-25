using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class OxygenCapsule : MonoBehaviour, IInteractable
{
    public float maxOxygen = 500f;
    public ThirdPersonController thirdPersonController;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {

    thirdPersonController.IncreaseOxygen();
    Destroy(gameObject);
    Debug.Log("Opening capsule");
    return true;
  
    }

}
