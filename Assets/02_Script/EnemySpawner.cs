using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefabs;

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

            GameObject enemy = Instantiate(EnemyPrefabs, transform);

            yield return new WaitForSeconds(2.5f);

        }
    }
}
