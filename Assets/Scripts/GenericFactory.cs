using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericFactory<T> : MonoBehaviour where T: MonoBehaviour
{
    [SerializeField] private T prefab;
    private Transform spawnPoint;
    private float n = 1.1f;

    private void Start()
    {
        spawnPoint = transform;
    }
    public T GetNewInstance()
    {
        Vector3 position = new Vector3(spawnPoint.position.x - n, 0, spawnPoint.position.z);
        n++;

        return Instantiate(prefab, position, Quaternion.identity);
    }
}
