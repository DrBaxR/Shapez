using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject randomWaveSpawner;
    public Text counter;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        randomWaveSpawner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time - startTime;
        string minutes = ((int)time / 60).ToString();
        string seconds = ((int)time % 60).ToString("f0");
        counter.text = minutes + ":" + seconds;
        if (Time.time > 60f)
        {
            randomWaveSpawner.SetActive(true);
        }
    }
}
