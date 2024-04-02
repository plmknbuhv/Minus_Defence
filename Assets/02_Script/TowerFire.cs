using System.Collections;
using UnityEngine;

public class TowerFire : MonoBehaviour
{
    private bool isDelay;
    [SerializeField] private GameObject _bullet;
    [HideInInspector] public GameObject _obj;
    [SerializeField] private Collider2D _distanceCol;
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

    private void Awake()
    {
        _distanceCol.enabled = false;
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
                Collider2D col = Physics2D.OverlapCircle(point, 0.4f);
                bool isContact = col == null;
                //bool isContact = Physics2D.OverlapCircle(point, 0.6f);
                Debug.Log(isContact + col?.gameObject.name);
                if (!isContact)
                {
                    return;
                }
                _distanceCol.enabled = true;
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