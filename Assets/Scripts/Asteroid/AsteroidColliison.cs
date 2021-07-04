using UnityEngine;

public class AsteroidColliison : ObjectCollisionBase
{
    private Asteroid _asteroid;
    private Spawner _spawner;
    private GameManager _gameManager;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
        _asteroid = GetComponent<Asteroid>();
        _gameManager = FindObjectOfType<GameManager>();

        _OnCollidedEvent += () => _spawner.SpawnParticles(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //In original game when player crashes into the asteroid he is not gaining score

        if (collision.CompareTag("Bullet"))
        {
            _gameManager.IncreaseScore(_asteroid.ScoreForDestroy);
            gameObject.SetActive(false);

            _OnCollidedEvent?.Invoke();
        }

        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            _OnCollidedEvent?.Invoke();
        }

    }
}
