using System.Collections;
using UnityEngine;

public class PlayerWarping : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private Camera _camera;
    private PlayerInput _input;

    [Space(15f)]
    [SerializeField] private float _warpEvasionTime = 2f;

    private void Awake()
    {
        _input = _target.GetComponent<PlayerInput>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_input.KeycodeWarp)) 
        {
            RandomWarp();
        }
    }

    public void RandomWarp()
    {
        if (!_target.activeInHierarchy) return;

        StartCoroutine(Check(_warpEvasionTime));

    }

    private IEnumerator Check(float amount)
    {
        _target.SetActive(false);

        yield return new WaitForSeconds(amount);

        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);

        Vector2 randomVector = _camera.ViewportToWorldPoint(new Vector2(randomX, randomY));

        _target.transform.position = randomVector;

        _target.SetActive(true);
    }
}
