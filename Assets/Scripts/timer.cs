using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class timer : MonoBehaviour

{
    public TextMeshProUGUI timerText;
    public float time = 11.0f;
    public TextMeshProUGUI endText;
    public GameObject player;
    public bool gameStarted = false;
    playerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
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
        playerScript.Win();
        Destroy(gameObject);
    }

}
