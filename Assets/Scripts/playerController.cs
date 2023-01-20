using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endText;
    public GameObject timer;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        score = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
        void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

        public void ChangeScore()
        {
        score = score + 1;
        Debug.Log("Score = " + score);
        scoreText.text = "Score = " + score + "/10";
        if (score == 10)
        {
            Win();
        }
    }

    public void Win()
    {
        if (score == 10)
        {
            endText.text = "You win!";
            gameObject.GetComponent <AudioSource>().clip = winMusic;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            endText.text = "You lose!";
            gameObject.GetComponent <AudioSource>().clip = loseMusic;
            gameObject.GetComponent<AudioSource>().Play();
        }
        gameObject.GetComponent<playerController>().enabled = false;
        timer.SetActive(false);
        scoreText.StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(5);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void timerStart()
    {
        timer.SetActive(true);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
