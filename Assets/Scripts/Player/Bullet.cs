using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float startForce = 30f;
    [SerializeField] private float deathDelay = 3f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(DisableObject(deathDelay));
    }

    public void AddStartForce()
    {
        Vector2 direction = transform.TransformDirection(Vector2.up);

        _rb.AddForce(direction * startForce, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private IEnumerator DisableObject(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.SetActive(false);
    }
}
