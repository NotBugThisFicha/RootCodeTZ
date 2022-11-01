using System.Collections.Generic;
using System;


[Serializable]
public class Score
{
    public string name;
    public float score;

    public Score(string name, float score)
    {
        this.name = name;
        this.score = score;
    }
}

[Serializable]
public class ScoreData
{
    public List<Score> scores;

    public ScoreData()
    {
        scores = new List<Score>();
    }
}
