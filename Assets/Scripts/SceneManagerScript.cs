using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    private Transform player;

    private void Awake() {
        player = GameObject.Find("PlayerArmature").transform;

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

}
