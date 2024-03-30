using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{

    [SerializeField] private GameObject _Bullet;
    public Collision2D _collision;

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collision = collision;
        Invoke("Fire_Bullet", 1);
    }

    private void Fire_Bullet()
    {
        Instantiate(_Bullet, transform);
    }
}
