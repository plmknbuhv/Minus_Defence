using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefabs;
    public float _spawnDelay = 11.5f;
    [SerializeField] private int _spawnCount = 1;
    [SerializeField] private int _spawnNum = 3;

    private void Start()
    {
        StartCoroutine("EnemySpawn");
    }

    private IEnumerator EnemySpawn()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                break;
            }

            for (int i = 0; i < _spawnNum; i++)
            {
                Instantiate(EnemyPrefabs, transform);
                yield return new WaitForSeconds(0.54f);
            }
            _spawnCount++;

            if (_spawnCount == 2)
            {
                MoneyManager._wave += 5;
                _spawnNum++;
                _spawnCount = 0;
            }

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
