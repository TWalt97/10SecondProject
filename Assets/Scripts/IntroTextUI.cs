using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTextUI : MonoBehaviour
{
    public GameObject player;
    playerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            playerScript.timerStart();
            Debug.Log("Timer should start");
            gameObject.SetActive(false);
        }
    }

}
