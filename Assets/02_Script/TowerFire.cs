using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerFire : MonoBehaviour
{
    private bool isDelay;
    [SerializeField] private GameObject _bullet;
    [HideInInspector] public Collider2D _collision;
    [HideInInspector] public GameObject _obj;
    public bool _canFire = false;
    Vector3 point;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_canFire)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (!isDelay)
                {
                    isDelay = true;
                    GameObject c_Bullet = Instantiate(_bullet, transform);
                    StartCoroutine("Fire_Delay");

                    Bullet bullet = c_Bullet.GetComponent<Bullet>();

                    bullet.obj = collision.gameObject;
                }
            }
        }
    }

    private void Update()
    {
        if (!_canFire) 
        {
            point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
            transform.position = point;

            if (Input.GetMouseButtonDown(0))
            {
                _canFire = true;
            }
        }
    }

    private IEnumerator Fire_Delay()
    {   
        yield return new WaitForSeconds(1f);
        isDelay = false;
    }
}