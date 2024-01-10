using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    private Transform player;
    
    [SerializeField] private OpenSceneTracker openSceneTracker;

    private void Awake() {
        openSceneTracker = FindFirstObjectByType<OpenSceneTracker>();
    }

    public void LoadScene(string sceneName){
        if(sceneName == "SettingsMenu" || sceneName == "Tutorial")
        {
            openSceneTracker.SetLastOpenScene(SceneManager.GetActiveScene().name);
        }

        if (sceneName == "Puzzle" || sceneName == "Puzzle 2" || sceneName == "Puzzle 3" || sceneName == "Puzzle 4" || sceneName == "SettingsMenu" ||sceneName == "GameOver")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        SceneManager.LoadScene(sceneName);
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