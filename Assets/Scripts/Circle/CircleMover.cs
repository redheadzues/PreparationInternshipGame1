using UnityEngine;

public class CircleMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private void Update()
    {
        _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
    }
}
