using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        playerController controller = other.GetComponent<playerController>();

        if (controller != null)
        {
            controller.ChangeScore();
            controller.PlaySound(collectedClip);
            Destroy(gameObject);
        }
    }
}
