using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletRef;
    [SerializeField] private Transform _muzzle;

    [SerializeField] private AudioFile _shootAudio;

    private Action _OnShootEvent;
    
    private PlayerInput _input;
    private ObjectPool _objectPool;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    private void OnEnable()
    {
        _OnShootEvent += () => AudioSystem.PlaySFX(transform.position, _shootAudio);
    }

    private void OnDisable()
    {
        _OnShootEvent -= () => AudioSystem.PlaySFX(transform.position, _shootAudio);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_input.KeycodeShoot))
        {
            _OnShootEvent?.Invoke();

            Bullet go = _objectPool.GetObject(_bulletRef).GetComponent<Bullet>();
            go.transform.SetPositionAndRotation(_muzzle.position, transform.rotation);
            
            // if try to use this method in OnEnable() method, rotation and position ignores.
            go.AddStartForce();
        }
    }
}
