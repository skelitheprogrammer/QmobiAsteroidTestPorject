using UnityEngine;

public class WaveObject : MonoBehaviour
{
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.waveObjects.Add(this);
    }

    private void OnDisable()
    {
        if (Application.isPlaying)
        {
            _spawner.waveObjects.Remove(this);
        }
    }
}
