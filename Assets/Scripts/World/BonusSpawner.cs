using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField, Range(0f, 15f)] private float _secondsToSpawn = 4f;

    private float _currentTime;

    private void Awake()
    {
        _currentTime = 0;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _secondsToSpawn)
        {
            _currentTime -= _secondsToSpawn;

            CreateNewBonus();
        }
    }

    private void CreateNewBonus()
    {
        var instance = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        instance.transform.position = transform.position + Vector3.up * 2f;

        var bonusType = RandomBonusTaker.GetRandomBonusType();
        instance.AddComponent(bonusType);
    }
}
