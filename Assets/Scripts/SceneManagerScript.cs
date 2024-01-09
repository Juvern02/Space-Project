using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    private Transform player;
    private OpenSceneTracker openSceneTracker;

    private void Awake() {
        player = GameObject.Find("PlayerArmature").transform;
        openSceneTracker = FindObjectOfType<OpenSceneTracker>();

        if (openSceneTracker == null)
        {
            Debug.LogError("OpenSceneTracker not found in the scene");
        }

        if (player == null)
        {
            Debug.Log("PlayerArmature not found in the scene");
        }

    }

    public void LoadScene(string sceneName){
        /*player = GameObject.Find("PlayerArmature").transform;
        if (player == null)
        {
            Debug.Log("PlayerArmature not found in the scene");
        }*/

        openSceneTracker.SetLastOpenScene(SceneManager.GetActiveScene().name);

        if (sceneName == "InsideSpaceShip")
        {
            SetPlayerPosition();
        }
        if (sceneName == "Puzzle" || sceneName == "Puzzle 2" || sceneName == "Puzzle 3" || sceneName == "Puzzle 4" || sceneName == "settingsMenu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        SceneManager.LoadScene(sceneName);
    }

    private void SetPlayerPosition()
    {
        if (player != null)
        {
            Vector3 newPosition = new(-44, 1, -50);
            player.position = newPosition;
            Debug.Log("New Position: " + newPosition);
        }
        else{
            Debug.LogError("player not assigned!");
        }
        
    }
    public void SetBarriers()
    {
        PlayerPrefs.SetInt("barrierKey", 0);
        Debug.Log(PlayerPrefs.GetInt("barrierKey"));
    }

    public void BackBtn()
    {
        string lastSceneName = OpenSceneTracker.Instance.GetLastOpenScene();
        SceneManager.LoadScene(lastSceneName);
    }
}
