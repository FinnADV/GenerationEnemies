using UnityEngine;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies  = new List<Enemy>();
    [SerializeField] private Enemy _prefab;

    public Enemy GetEnemy()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy.gameObject.activeInHierarchy == false)
            {
               return enemy;
            }
        }

        Enemy newEnemy = Instantiate(_prefab);

        _enemies.Add(newEnemy);

        return newEnemy;
    }
}