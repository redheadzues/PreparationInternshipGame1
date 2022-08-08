using UnityEngine;

[RequireComponent(typeof(Circle))]
public class CircleCollisionHandler : MonoBehaviour
{
    private Circle _circle;   

    private void Start()
    {
        _circle = GetComponent<Circle>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Saw saw))
            _circle.Die();

        if (collision.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            _circle.IncreaseScore();
        }
    }
}
