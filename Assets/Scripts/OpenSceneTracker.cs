using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneTracker : MonoBehaviour
{
    public static OpenSceneTracker Instance;

    private string lastSceneKey = "LastOpenScene";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLastOpenScene(string sceneName)
    {
        PlayerPrefs.SetString(lastSceneKey, sceneName);
        PlayerPrefs.Save();
    }

    public string GetLastOpenScene()
    {
        return PlayerPrefs.GetString(lastSceneKey, "DefaultScene");
    }
}
