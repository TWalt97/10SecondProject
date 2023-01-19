using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class timer : MonoBehaviour

{
    public TextMeshProUGUI timerText;
    public float time = 10.0f;
    public TextMeshProUGUI endText;
    public playerController player;
    public bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted == true)
        {
                time -= Time.deltaTime;
                int seconds = (int)(time % 60);

                if (time <= 0.0f)
                {
                    timerEnded();
                    Debug.Log("Timer ended");
                }

                timerText.text = seconds.ToString();           
            }
    }

    void timerEnded()
    {
        player.Win();
    }

}
