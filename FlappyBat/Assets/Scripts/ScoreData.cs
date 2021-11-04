using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu (fileName = "Score", menuName = "Custom Scripts/Scriptable Objects/Score", order = 0)]
public class ScoreData : CustomScriptableObject
{
    public int points = 0;

    public int HighScore = 0;

    public GameEvent HighScoreBeatenEvent;

    private bool highScoreBeatenThisSession = false;

    public void Reset()
    {
        points = 0;
        highScoreBeatenThisSession = false;
    }

    public void Increment(int withPoints)
    {
        points += withPoints;

        if (HighScore <= points)
        {
            HighScore = points;

            RaiseEvent ();
        }

    }

    private void RaiseEvent()
    {
        if (!highScoreBeatenThisSession)
        {
            highScoreBeatenThisSession = true;
            HighScoreBeatenEvent.RaiseEvent ();
        }
    }
}
