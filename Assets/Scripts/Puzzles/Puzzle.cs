using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public int[] correctRotation;
    public bool correct;
    private int currentRotation;

    private void Start()
    {
        CheckForCorrectRotation();
    }

    private void OnMouseDown()
    {
        if (currentRotation >= 270)
        {
            currentRotation = 0;
        }
        else
        {
            currentRotation += 90;
        }
        transform.Rotate(new Vector3(0, 0, 90));
        CheckForCorrectRotation();
    }

    private void CheckForCorrectRotation()
    {
        correct = false; 
        for (int i = 0; i < correctRotation.Length; i++)
        {
            if (currentRotation == correctRotation[i])
            {
                correct = true;
                break;
            }
        }
    }
}
