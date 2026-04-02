using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnDelay = 2f;

    private bool _isWork = true;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (_isWork)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);

            SpawnPoint point = _spawnPoints[randomIndex];

            Enemy newEnemy = Instantiate(_enemyPrefab,transform.position, Quaternion.identity);

            Vector3 direction = point.GetDirection();

            direction.y = 0;

            newEnemy.SetDirection(direction);

            yield return wait;
        }
    }
}