using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    private bool gameStarted = false;
    public GameObject[] barrier;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            barrier[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int barrierIndex = PlayerPrefs.GetInt("barrierKey");
        if (barrierIndex > 0)
        {
            for (int i = 0; i < barrierIndex; i++)
            {
                barrier[i].SetActive(false);
            }
        }
    }
}
