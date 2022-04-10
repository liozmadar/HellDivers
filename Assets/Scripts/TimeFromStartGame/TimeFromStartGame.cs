using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeFromStartGame : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float timer = 0;
    public int intTimer = 0;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            intTimer++;
            timer = 0f;
        }
        timerText.text = intTimer.ToString();
    }
}
