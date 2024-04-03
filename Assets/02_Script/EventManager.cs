using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EventManager : MonoBehaviour
{
    [HideInInspector] public GameObject c_Tower;
    [SerializeField] private GameObject _towerPrefab;

    public void FirstButtonClick()
    {
        c_Tower = Instantiate(_towerPrefab);
        TowerFire _tower = GetComponent<TowerFire>();
    }
}
