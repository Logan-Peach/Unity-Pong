using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] private Text winnerText;
    void Start()
    {
        if (ScoreScript.winner.Equals("red"))
        {
            winnerText.color = Color.red;
            winnerText.text = "Red Wins";
        }
        if (ScoreScript.winner.Equals("blue"))
        {
            winnerText.color = Color.blue;
            winnerText.text = "Blue Wins";
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
