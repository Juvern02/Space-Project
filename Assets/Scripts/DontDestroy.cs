using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private Health playerHealth;
    private OxygenController playerOxygen;
    [System.Obsolete]
    void Start()
    {
        playerHealth = FindFirstObjectByType<Health>();
        playerOxygen = FindFirstObjectByType<OxygenController>();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.slider.value > 0 && playerOxygen.slider.value > 0)
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("Dont Destory " + playerHealth.slider.value + " " + playerOxygen.slider.value);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroy " + playerHealth.slider.value + " " + playerOxygen.slider.value);
        }
    }
}
