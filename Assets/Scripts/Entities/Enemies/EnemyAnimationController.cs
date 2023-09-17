using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    public void PlayDyingAnimation()
    {
        ParticlesController.EmitParticleSystemBeforeParentDeletion(_particles, 100);
    }
}
