using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _Enemy;

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

            Instantiate(_Enemy, transform);
            yield return new WaitForSeconds(2.5f);

        }
    }
}
