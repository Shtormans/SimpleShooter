using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyMover _mover;
    private EnemyAnimationController _animator;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _animator = GetComponent<EnemyAnimationController>();
    }

    public void TakeDamage()
    {
        _animator.PlayDyingAnimation();

        Destroy(gameObject);
    }

    public void Activate(PlayerController targetObject)
    {
        _mover.Target = targetObject.transform;
    }
}
