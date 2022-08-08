using UnityEngine;

public class CircleJumper : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded = true;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            if (_isGrounded)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _isGrounded = false;
            }
            else
            {
                _rigidbody.AddForce(Vector2.down * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
        {
            _isGrounded = true;
        }
    }
}
