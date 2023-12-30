using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySetterScript : MonoBehaviour
{
    [SerializeField] private Text difficultyText;

    private void Start()
    {
        SetDifficultyText();
    }

    private void SetDifficultyText()
    {
        difficultyText.text = ComputerPaddleScript.difficulty.ToString().ToUpper();
    }

    public void SetEasy()
    {
        ComputerPaddleScript.difficulty = "easy";
        SetDifficultyText();
    }

    public void SetNormal()
    {
        ComputerPaddleScript.difficulty = "normal";
        SetDifficultyText();
    }

    public void SetHard()
    {
        ComputerPaddleScript.difficulty = "hard";
        SetDifficultyText();
    }
}
