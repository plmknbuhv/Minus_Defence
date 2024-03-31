using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool isDelay;
    [SerializeField] private GameObject _bullet;
    [HideInInspector] public Collider2D _collision;

    private void OnTriggerStay2D(Collider2D collision)
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

    private IEnumerator Fire_Delay()
    {   
        yield return new WaitForSeconds(1f);
        isDelay = false;
    }
}