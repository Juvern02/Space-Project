using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promtText;

    private void Start() {
        cam = Camera.main;
        _uiPanel.SetActive(false);
    }
    private void LateUpdate() {
        var rotation = cam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool IsDisplayed = false;
    public void SetUp(string promptText){
        _promtText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close(){
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
