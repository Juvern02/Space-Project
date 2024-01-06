using UnityEngine;
using TMPro;
using System.Collections;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent; 
    public string fullText;
    public float typingSpeed = 0.05f;
    private string currentText = "";


    public void DisplayText()
    {
        textComponent.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
