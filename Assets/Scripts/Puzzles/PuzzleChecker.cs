using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
    public GameObject Win;
    public Puzzle[] puzzles;

    private void Start()
    {
        Win.SetActive(false);
    }

    void Update()
    {
        bool allPuzzlesCorrect = true;
        foreach (Puzzle puzzle in puzzles)
        {
            if (!puzzle.correct)
            {
                allPuzzlesCorrect = false;
                break;
            }
        }
        if (allPuzzlesCorrect)
        {
            Win.SetActive(true);
            gameObject.SetActive(false);
            Invoke("ReturnToShip", 3f);
        }
    }

    private void ReturnToShip()
    {
        SceneManagerScript sceneManager = new SceneManagerScript();
        sceneManager.LoadScene("InsideSpaceShip");
    }
}
