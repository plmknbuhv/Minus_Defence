using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 moveDir;
    [HideInInspector] public GameObject obj;
    [SerializeField] private float _speed = 3.5f;

    void Update()
    {
        SetObject();
    }

    public void SetObject()
    {
        moveDir = obj.transform.position - transform.position;
        moveDir.Normalize();
        transform.position += moveDir * _speed * Time.deltaTime;
    }
}
