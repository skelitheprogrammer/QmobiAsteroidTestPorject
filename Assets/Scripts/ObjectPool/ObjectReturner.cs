using UnityEngine;

public class ObjectReturner : MonoBehaviour
{
    private ObjectPool _objectPool;

    private void Awake()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    private void OnDisable()
    {
        _objectPool.ReturnObject(gameObject);
    }
}
