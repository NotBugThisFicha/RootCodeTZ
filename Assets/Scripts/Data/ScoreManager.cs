using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData scoreData;

    private static ScoreManager instance;

    public static ScoreManager Instance { get { return instance; } private set { } }


    void Awake()
    {
        var json = PlayerPrefs.GetString("Scores", "{}");
        scoreData = JsonUtility.FromJson<ScoreData>(json);

        if (instance == null)
            instance = this;
        else Destroy(gameObject);

    }

    public void AddScore(Score score)
    {
        Score scoreFind = scoreData.scores.Find(x => x.name == score.name);
        int indexScorefind = scoreData.scores.IndexOf(scoreFind);

        if (scoreData.scores == null || scoreFind == null)
            scoreData.scores.Add(score);
        else if (scoreFind != null)
            scoreData.scores[indexScorefind] = score;
    }

    public IEnumerable<Score> GetScore()
    {
        return scoreData.scores.OrderByDescending(x => x.score);
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString("Scores", json);
    }
    private void OnDestroy()
    {
        SaveScore();
    }
}
