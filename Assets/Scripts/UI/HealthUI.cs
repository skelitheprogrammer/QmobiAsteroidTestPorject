using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _healthIconRef;

    [SerializeField] private Transform healthContainer;

    private readonly Stack<GameObject> healthIcons = new Stack<GameObject>();

    private PlayerManager _playerManager;
    
    private void Awake()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Start()
    {
        SpawnHealthUI();

    }

    private void SpawnHealthUI()
    {
        for (int i = 0; i < _playerManager.Health; i++)
        {
            GameObject go = Instantiate(_healthIconRef, healthContainer);
            healthIcons.Push(go);
        }
    }

    public void DecreaseHealthUI()
    {
        GameObject go = healthIcons.Pop();
        Destroy(go);
    }
}
