using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public ScoreData scoreData;

    public void UpdateScore()
    {
        scoreText.text = scoreData.points + "";
    }
}
