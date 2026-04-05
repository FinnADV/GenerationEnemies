using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private EnemyPool _pool;
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

            Enemy newEnemy = _pool.GetEnemy();

            newEnemy.transform.position = transform.position;

            newEnemy.gameObject.SetActive(true);

            Vector3 direction = point.Direction;

            direction.y = 0;

            newEnemy.SetDirection(direction);

            yield return wait;
        }
    }
}