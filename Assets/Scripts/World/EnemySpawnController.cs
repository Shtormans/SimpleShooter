using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField, Range(0f, 15f)] private float _secondsToSpawn = 4f;
    [SerializeField, Range(0, 20)] private int _enemyAmountAtATime = 1;
    [SerializeField] private List<EnemySpawner> _spawners;

    private List<GameObject> _enemyPrefabs;
    private float _currentTime;

    private void Awake()
    {
        _enemyPrefabs = Resources.LoadAll<GameObject>(ResourcesPaths.ToEnemyPrefabsFolder).ToList();

        _currentTime = 0;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _secondsToSpawn)
        {
            _currentTime -= _secondsToSpawn;

            for (int i = 0; i < _enemyAmountAtATime; i++)
            {
                CreateNewEnemy();
            }
        }
    }

    private void CreateNewEnemy()
    {
        int spawnerIndex = Random.Range(0, _spawners.Count - 1);
        int enemyIndex = Random.Range(0, _enemyPrefabs.Count - 1);

        var enemy = _enemyPrefabs[enemyIndex];
        var position = _spawners[spawnerIndex].transform.TransformDirection(_spawners[spawnerIndex].transform.position);

        var instance = Instantiate(enemy, position, Quaternion.identity);
        instance.GetComponent<EnemyController>().Activate(_player);
    }
}
