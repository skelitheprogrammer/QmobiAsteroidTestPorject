using UnityEngine;

public class PlayerCollision : ObjectCollisionBase
{
    private PlayerManager _playerManager;
    private Spawner _spawner;
    private void Awake()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _spawner = FindObjectOfType<Spawner>();
        _OnCollidedEvent += () => _spawner.SpawnParticles(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet"))
        {
            _playerManager.Die();
        }

        _OnCollidedEvent?.Invoke();
    }

}
