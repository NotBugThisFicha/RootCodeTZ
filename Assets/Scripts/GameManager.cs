using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CubeFactory cubeFactory;

    private List<Cube> cubes = new List<Cube>();

    private int startDestinationP = 0;
    private int finishDestinationP = 0;

    private int idCube = 1;

    private static GameManager instance;

    public static GameManager Instance { get { return instance; } private set { } }


    private void Awake()
    {

        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void InitDestinationPointStart(int value) => startDestinationP = value;

    public void InitDestinationPointFinish(int value) => finishDestinationP = value;

    public void InstantiateCube()
    {
        Debug.Log(startDestinationP + " : " + finishDestinationP);
        if (finishDestinationP != 0)
        {
            Cube cube;

            Transform[] wayPoints = new Transform[finishDestinationP - startDestinationP];

            int f = 0;
            for (int i = startDestinationP; i < finishDestinationP; i++)
            {
                wayPoints[f] = Path.Instance.Segments[i];
                f++;
            }

            cube = cubeFactory.GetNewInstance();
            cube.name = $"Cube {idCube}";
            idCube++;
            cube.SetWayPoints(wayPoints);
            cubes.Add(cube);
        }
           

        startDestinationP = -1;
        finishDestinationP = -1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        SetScores();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ReloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    private void SetScores()
    {
        if(cubes.Count > 0)
        {
            for(int i = 0; i< cubes.Count; i++)
            {
                ScoreManager.Instance.AddScore(new Score(cubes[i].name, cubes[i].Score + 1));
            }
        }
    }
}
