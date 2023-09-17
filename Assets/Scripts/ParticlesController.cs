using UnityEngine;

public static class ParticlesController
{
    public static void PlayParticleSystemBeforeParentDeletion(ParticleSystem _particles)
    {
        _particles.transform.parent = null;

        _particles.Play();

        GameObject.Destroy(_particles.gameObject, 2f);
    }

    public static void EmitParticleSystemBeforeParentDeletion(ParticleSystem _particles, int emitCount)
    {
        _particles.transform.parent = null;

        _particles.Emit(emitCount);

        GameObject.Destroy(_particles.gameObject, 2f);
    }
}
