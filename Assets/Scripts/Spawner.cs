using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //The game does not involve dynamic changes in the spawn of objects, so I chose this method
    public readonly List<WaveObject> waveObjects = new List<WaveObject>();

    [SerializeField] private int asteroidSpawnCount;

    [Space(15f)]
    [SerializeField] private GameObject _asteroidReference;
    [SerializeField] private GameObject _crashParticlesReference;

    private ObjectPool _objectPool;

    private void Awake()
    {
        _objectPool = GetComponent<ObjectPool>();

       // SpawnWave();
    }

    private void Update()
    {
        if (waveObjects.Count == 0)
        {
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        for (int i = 0; i < asteroidSpawnCount; i++)
        {
            GameObject go = _objectPool.GetObject(_asteroidReference);
            go.transform.SetPositionAndRotation(CalcRandomSpawnPosition(), CalcRandomRotation());
        }
    }

    public void SpawnObject(GameObject go, Vector2 position, int count)
    {

        for (int i = 0; i < count; i++)
        {
            GameObject newGO = _objectPool.GetObject(go);
            newGO.transform.SetPositionAndRotation(position, CalcRandomRotation());
        }
    }

    public void SpawnParticles(Vector2 position)
    {
        GameObject go = _objectPool.GetObject(_crashParticlesReference);
        go.transform.position = position;
    }

    //https://stackoverflow.com/questions/25891033/get-a-random-float-within-range-excluding-sub-range
    private Vector2 CalcRandomSpawnPosition()
    {
        var excluded = 0.6f - 0.3f;
        var newMax = 1 - excluded;

        var randomX = Random.Range(0, newMax);
        var randomY = Random.Range(0, newMax);

        if (randomX > 0.3f)
        {
            randomX += excluded;
        }

        if (randomY > 0.3f)
        {
            randomY += excluded;
        }

        return Camera.main.ViewportToWorldPoint(new Vector2(randomX, randomY));

    }

    private Quaternion CalcRandomRotation()
    {
        float randomRotation = Random.Range(0, 1f + .1f);

        return new Quaternion(0, 0, randomRotation, 1f);
    }
}
