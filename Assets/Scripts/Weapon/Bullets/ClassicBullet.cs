using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ClassicBullet : Bullet
{
    [SerializeField] private float _force = 80f;
    
    private Rigidbody _rigidbody;

    public override BulletType Type => BulletType.Classic;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = Vector3.zero;

        _startPosition = transform.position;

        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private void Update()
    {
        DeleteOnDistance();
    }

    private void OnTriggerEnter(Collider collider)
    {
        var other = collider.gameObject;

        if (other.TryGetComponent(out EnemyController enemy))
        {
            enemy.TakeDamage();
        }
        else if (other.TryGetComponent(out PlayerController player))
        {
            return;
        }

        Deactivate();
    }

    

    protected override void Deactivate()
    {
       gameObject.SetActive(false);
    }
}
