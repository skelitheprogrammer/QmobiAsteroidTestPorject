using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private int _health = 3;
    public int Health => _health;

    [Space(15f)]
    [SerializeField] private float respawnDelay = 2f;
    [SerializeField] private float overlapRadius = 3f;

    [Space(15f)]
    [SerializeField] private AudioFile _deathAudio;

    [SerializeField] private UnityEvent _OnDieEvent;
    [SerializeField] private UnityEvent _OnHealthChangedEvent;

    private GameManager _gameManager;

    public LayerMask enemyMasks;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        _OnDieEvent.AddListener(() => AudioSystem.PlaySFX(_deathAudio));
    }

    private void OnDisable()
    {
        _OnDieEvent.RemoveListener(() => AudioSystem.PlaySFX(_deathAudio));
    }

    public void Die()
    {
        _player.SetActive(false);

        _health -= 1;
        
        CheckHealth();

        StartCoroutine(Respawn(respawnDelay));
        _OnDieEvent?.Invoke();
    }

    private void CheckHealth()
    {
        if (_health == 0)
        {
            _gameManager.OnGameOverEvent?.Invoke();
        }

        _OnHealthChangedEvent?.Invoke();
    }

    private IEnumerator Respawn(float time)
    {
        while(time > 0)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(Vector2.zero, overlapRadius, enemyMasks);
            yield return null;

            if (colliders.Length == 0)
            {
                time -= Time.deltaTime;
                Debug.Log(time);
                yield return null;
            }

            if (time <= 0)
            {
                _player.transform.position = Vector2.zero;

                _player.SetActive(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector2.zero, overlapRadius);
    }
}
