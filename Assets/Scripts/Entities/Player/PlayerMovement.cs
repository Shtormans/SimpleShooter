using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0, 100f)] private float _speed = 10f;
    [SerializeField, Range(0, 100f)] private float _jumpForce = 10f;
    [SerializeField, Range(1, 10)] private int _jumpsAmount = 2;

    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private int _jumpsLeft;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _jumpsLeft = _jumpsAmount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
        _jumpsLeft = _jumpsAmount;
    }

    public void MoveInDirection(Vector3 direction)
    {
        var worldDirection = transform.TransformDirection(direction);

        var offset = worldDirection * _speed * Time.deltaTime;
        var newPosition = transform.position + offset;

        _rigidbody.MovePosition(newPosition);
    }

    public void TryJump()
    {
        if (_isGrounded || _jumpsLeft > 0)
        {
            var vectorForce = transform.up * _jumpForce;

            _rigidbody.AddForce(vectorForce, ForceMode.Impulse);

            _isGrounded = false;

            _jumpsLeft--;
        }
    }

    public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        _rigidbody.AddExplosionForce(1000f, explosionPosition, explosionRadius);
    }
}
