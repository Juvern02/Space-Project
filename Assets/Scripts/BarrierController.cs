using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
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
        Debug.Log(barrierIndex);
        if (barrierIndex > 0)
        {
            for (int i = 0; i < barrierIndex; i++)
            {
                barrier[i].SetActive(false);
            }
        }
    }
}
