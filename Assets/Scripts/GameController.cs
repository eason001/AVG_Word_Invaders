using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText goText;
    public GUIText reText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start () {
        gameOver = false;
        restart = false;
        reText.text = "";
        goText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine( SpawnWaves());
	}
	
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

	IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                reText.text = "Press R to restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newscore)
    {
        score += newscore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        goText.text = "GAME OVER";
        gameOver = true;
    }
}
