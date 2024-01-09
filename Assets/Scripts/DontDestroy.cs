using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private Health playerHealth;
    [System.Obsolete]
    void Start()
    {
        playerHealth = FindFirstObjectByType<Health>();
        if (playerHealth.currentHealth > 0)
        {
            for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
            {
                if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
                {
                    if (Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                    {
                        Destroy(gameObject);
                    }
                }
            }
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
