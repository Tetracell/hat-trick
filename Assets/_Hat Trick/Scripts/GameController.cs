using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject ball;
    public float timeLeft;
    public Text timeText;
    public Text scoreText;
    public GameObject gameOvertext;
    public GameObject restartButton;
    public GameObject startButton;
    public GameObject splash;

    private float maxWidth;
    private Renderer ballWidth;
    private bool playing;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        playing = false;
        ballWidth = ball.GetComponent<Renderer>();
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        var sack = ballWidth.bounds.extents.x;
        maxWidth = targetWidth.x - sack;
        gameOvertext.SetActive(false);
        restartButton.SetActive(false);
    }

    void FixedUpdate()
    {
        if (playing)
        {
            timeLeft -= Time.deltaTime;
            updateTimeText();
            if (timeLeft < 0)
            {
                timeLeft = 0;
            }
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        playing = true;
        while (timeLeft > 0)
        {
            Vector3 spawnPosition = new Vector3
                (
                Random.Range(-maxWidth, maxWidth),  //x position
                transform.position.y,               //y position
                0.0f                                //z position
                );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }
        yield return new WaitForSeconds(1.5f);
        gameOvertext.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        restartButton.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(Spawn());
        splash.SetActive(false);
        startButton.SetActive(false);
    }

    void updateTimeText()
    {
        timeText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }

	
	// Update is called once per frame
	void Update ()
    {
	}
}
