using UnityEngine;

public class Cube : MonoBehaviour
{
    private Transform[] wayPoints;
    private int i;
    [SerializeField] private float speed;

    [HideInInspector] public string name;
    private int score;
    public int Score { get { return score; } private set { } }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = name;
    }

    public void SetWayPoints(Transform[] wayPoints)
    {
        this.wayPoints = wayPoints;
        Debug.Log(wayPoints.Length);
    }
    // Update is called once per frame
    void Update()
    {
        if(wayPoints != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[i].position, Time.deltaTime * speed);
            transform.LookAt(wayPoints[i].position);
            if (Vector3.Distance(transform.position, wayPoints[i].position) < .01f && i < wayPoints.Length - 1)
            {
                i++;
                score++;
            }
        }
    }
}
