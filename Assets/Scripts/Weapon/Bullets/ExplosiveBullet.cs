using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class ExplosiveBullet : Bullet
{
    [SerializeField] private float _force = 80f;
    [SerializeField] private float _explosionSize = 17f;
    [SerializeField] private float _explosionForce = 20f;
    [SerializeField] private ParticleSystem _explosionParticles;
    
    private Rigidbody _rigidbody;
    private MeshRenderer _bulletMesh;

    private bool _isUsed;

    public override BulletType Type => BulletType.Explosive;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _bulletMesh = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        _bulletMesh.enabled = true;
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector3.zero;

        _startPosition = transform.position;

        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private void Update()
    {
        DeleteOnDistance();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            return;
        }

        Deactivate();
    }

    protected override void Deactivate()
    {
        var colliders = Physics.OverlapSphere(transform.position, _explosionSize);
        foreach (var collider in colliders)
        {
            var other = collider.gameObject;

            if (other.TryGetComponent(out EnemyController enemy))
            {
                enemy.TakeDamage();
            }
            else if (other.TryGetComponent(out PlayerMovement player))
            {
                player.AddExplosionForce(_explosionForce, transform.position, _explosionSize);
            }
        }

        StartCoroutine(StartExplosion());
    }

    private IEnumerator StartExplosion()
    {
        _bulletMesh.enabled = false;

        _explosionParticles.Emit(20);

        _rigidbody.isKinematic = true;

        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);

        yield return null;
    }
}
