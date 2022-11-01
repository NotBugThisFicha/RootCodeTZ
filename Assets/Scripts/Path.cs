using System.Collections.Generic;
using UnityEngine;

public enum Letter
{
    A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, Count
}
public class Path : MonoBehaviour
{
    private List<Transform> segmentPos;
    private GameObject[] segments;

    private static Path instance;

    public static Path Instance { get { return instance; } private set { } }

    public List<Transform> Segments { get { return segmentPos; } private set { } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        segmentPos = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
            segmentPos.Add(transform.GetChild(i));
    }
    public void GenerateSegments()
    {
        segmentPos = new List<Transform>();

        for (int i = 0; i < (int)Letter.Count; i++)
        {
            GameObject go = new GameObject($"{i}");
            go.transform.SetParent(this.transform);
            segmentPos.Add(go.transform);
        }

        for (int i = 0; i < segmentPos.Count - 1; i++)
        {
            int f = i + 1;
            segmentPos[f].position = new Vector3(segmentPos[i].position.x - 2, 0, segmentPos[i].position.z);
        }
    }

    
    public void ResetPath()
    {
        for (int i = 0; i < segmentPos.Count; i++)
        {
            segmentPos[i].position = Vector3.zero;
        }
        for (int i = 0; i < segmentPos.Count - 1; i++)
        {
            int f = i + 1;
            segmentPos[f].position = new Vector3(segmentPos[i].position.x - 2, 0, segmentPos[i].position.z);
        }
    }

    public void DeletePath()
    {
        segments = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            segments[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in segments)
            DestroyImmediate(go);
            
        
        segments = null;
    }
    private void OnDrawGizmos()
    {
        if(transform.childCount != 0)
        {
            Gizmos.color = Color.red;
            int f = 0;
            for (int i = 0; i < transform.childCount; i++)
            { 
                Gizmos.DrawSphere(transform.GetChild(i).position, 0.2f);

                f = i + 1;

                if (f < transform.childCount) 
                    Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(f).position);
            }  
        }
    }
}
