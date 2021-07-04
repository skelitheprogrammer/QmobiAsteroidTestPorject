using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int _startMinForce = 10;
    [SerializeField] private int _startMaxForce = 10;

    [SerializeField] private int _scoreForDestroy = 10;
    public int ScoreForDestroy => _scoreForDestroy;

    private Rigidbody2D _rb;
    private GameManager _gameManager;
    private Spawner _spawner;

    [SerializeField] private GameObject nextObjectSpawn;
    [SerializeField] private int nextObjectCount;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
        _spawner = FindObjectOfType<Spawner>();
    }

    private void OnEnable()
    {
        Init();
    }
    private void OnDisable()
    {
        if (Application.isPlaying)
        {
            if (nextObjectSpawn != null)
            {
                _spawner.SpawnObject(nextObjectSpawn, transform.position, nextObjectCount);
            }
        }
    }

    private void Init()
    {
        float randomX = Random.Range(-1f, 1.01f);
        float randomY = Random.Range(-1f, 1.01f);
        Vector2 randomDirection = new Vector2(randomX, randomY);

        int randomForce = Random.Range(_startMinForce, _startMaxForce + 1);

        _rb.AddRelativeForce(randomDirection * randomForce, ForceMode2D.Force);
    }
}
