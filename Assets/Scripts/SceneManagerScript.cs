using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    private Transform player;
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake() {
        player = GameObject.Find("PlayerArmature").transform;
        //starterAssetsInputs = GameObject.Find("PlayerArmature").GetComponent<StarterAssetsInputs>();

        if (player == null)
        {
            Debug.Log("PlayerArmature not found in the scene");
        }
        
    }
    public void LoadScene(string sceneName){
        if (sceneName == "InsideSpaceShip")
        {
            SetPlayerPosition();
        }
        if (sceneName == "Puzzle" || sceneName == "Puzzle 2" || sceneName == "Puzzle 3" || sceneName == "Puzzle 4")
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

}
