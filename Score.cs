using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text txt;
    int score = 1;
    string text;

    public void SetScore()
    {
        text = score.ToString();
        txt.text = "Score: " + text;
        score++;
        
    }
}
