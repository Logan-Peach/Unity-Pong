using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCapSetterScript : MonoBehaviour
{
    [SerializeField] private Text scoreCapText;

    private void Start()
    {
        SetScoreCapText();
    }

    private void SetScoreCapText()
    {
        scoreCapText.text = ScoreScript.scoreCap.ToString();
    }

    public void MinusScoreCap()
    {
        if (ScoreScript.scoreCap > 0) 
        {
            ScoreScript.scoreCap -= 1;
            SetScoreCapText();
        }
    }

    public void PlusScoreCap()
    {
        if (ScoreScript.scoreCap < 100)
        {
            ScoreScript.scoreCap += 1;
            SetScoreCapText();
        }
    }
}
