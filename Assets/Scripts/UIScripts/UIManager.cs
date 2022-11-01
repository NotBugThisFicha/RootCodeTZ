using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreMenu;
    [SerializeField] private Button pauseGame_B;
    [SerializeField] private Button showScores_B;
    [SerializeField] private Button reload_B;

    private static UIManager instance;
    public static UIManager Instance { get { return instance; } private set { } }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    public void ShowLeaderBoard()
    {
        GameManager.Instance.PauseGame();

        scoreMenu.SetActive(true);
        pauseGame_B.gameObject.SetActive(false);
        showScores_B.gameObject.SetActive(false);
        reload_B.gameObject.SetActive(false);
    }

    public void HideLeaderBoard()
    {
        scoreMenu.SetActive(false);
        pauseGame_B.gameObject.SetActive(true);
        showScores_B.gameObject.SetActive(true);
        reload_B.gameObject.SetActive(true);

        GameManager.Instance.ResumeGame();
    }
}
