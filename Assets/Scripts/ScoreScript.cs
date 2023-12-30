using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public int redScore = 0;
    public int blueScore = 0;
    public static int scoreCap = 3;

    public static string winner = "none";

    [SerializeField] Text redScoreText;
    [SerializeField] Text blueScoreText;

    private void Start()
    {
        winner = "none";
    }

    private void Update()
    {
        redScoreText.text = redScore.ToString();
        blueScoreText.text = blueScore.ToString();

        if (scoreCap != 0)
        {
            if (redScore >= scoreCap)
            {
                Debug.Log(winner);
                winner = "red";
                Invoke(nameof(LoadNextScene), 0.3f);
            }
            else if (blueScore >= scoreCap)
            {
                winner = "blue";
                Invoke(nameof(LoadNextScene), 0.3f);
            }
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
