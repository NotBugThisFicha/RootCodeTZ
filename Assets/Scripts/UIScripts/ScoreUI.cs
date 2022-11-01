using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private RowUI rowUI;
    private ScoreManager scoreManager;

    private List<RowUI> content = new List<RowUI>();

    void OnEnable()
    {
        scoreManager = ScoreManager.Instance;

        var scores = scoreManager.GetScore().ToArray();

        for(int i = 0; i< scores.Length; i++)
        {
            RowUI row = null;

            if (content.Count == 0 || content[i].name.text != scores[i].name)
                row = Instantiate(rowUI, transform).GetComponent<RowUI>();

            if(row != null)
                content.Add(row);

            content[i].name.text = scores[i].name;
            content[i].score.text = $"{scores[i].score}";
        }
    }
}
