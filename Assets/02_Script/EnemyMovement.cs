using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.TerrainUtils;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private HpBar _hpBar;
    [SerializeField] private TileBase _tile;
    [SerializeField] private TileBase _flagtile;
    [SerializeField] private Vector3Int _beforeDirection;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private PlayerHp _playerHp;
    private Transform _transform;

    private void Awake()
    {
        _tilemap = GameObject.Find("Route").GetComponent<Tilemap>();
        _hpBar = transform.Find("HpBar").GetComponent<HpBar>();
        _transform = transform.Find("Visual");
        _playerHp = GameObject.Find("PlayerHpBar").GetComponent<PlayerHp>();
    }

    private void Start()
    {
        StartCoroutine(FindRoute());
    }

    private void Update()
    {
        if (_hpBar.curHp <= 0)
        {
            DOTween.Kill(transform);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        DOTween.Kill(transform);
    }

    private IEnumerator FindRoute()
    {
        while (true) // ���� �ݺ���
        {
            if (gameObject != null)
            {
                yield return null; // �ƹ� �͵� �������� ������ ������ �ݺ��� �����ϱ� ��ƽ�� ����

                if (Input.GetKeyDown(KeyCode.F12)) // ���� f12�� ������ 
                    break; // �ڵ� Ż��

                foreach (var dir in Directions.DIRECTIONS) // ���� �迭�� �ݺ�
                {
                    Vector3Int tilepos = _tilemap.WorldToCell(transform.position); // Enemy�� ��ġ�� Vector3Int�� �ٲ� ����
                    tilepos += dir; // ��, ��, ��, �� 4������ Ÿ���� üũ

                    var tile = _tilemap.GetTile(tilepos); // üũ�� Ÿ���� ����

                    if (tile != null) // Ÿ���� �ִٸ�
                    {
                        if (dir == -_beforeDirection) continue; // ���� �Դ� ���� Ÿ���̶�� ��ŵ

                        /*�� �̵� ���⺰�� Enemy�� ���� ��ȯ*/
                        if (dir == Directions.DIRECTIONS[0])
                        {
                            _transform.rotation = Quaternion.Euler(0, 0, 0);
                        }
                        else if (dir == Directions.DIRECTIONS[1])
                        {
                            _transform.rotation = Quaternion.Euler(0, 0, 180);
                        }
                        else if (dir == Directions.DIRECTIONS[2])
                        {
                            _transform.rotation = Quaternion.Euler(0, 0, 270);
                        }
                        else if (dir == Directions.DIRECTIONS[3])
                        {
                            _transform.rotation = Quaternion.Euler(0, 0, 90);
                        }

                        transform.DOMove(tilepos, 1 / _moveSpeed).SetEase(Ease.Linear);

                        _beforeDirection = dir;
                        yield return new WaitForSeconds(1 / _moveSpeed);
                    }
                    if (_tilemap.GetTile(_tilemap.WorldToCell(transform.position)) == _flagtile) // Ÿ���� �ִٸ�
                    {
                        Destroy(gameObject);
                        _playerHp.PlayerHit();
                        break;
                    }
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            _hpBar.Hit();
        }
    }
}

class Directions // ������ ���� ���� Ŭ���� ����
{
    public static Vector3Int[] DIRECTIONS = new Vector3Int[] // static���� Vector3Int���� �迭 ����
    {
        new Vector3Int(0,1), // ��
        new Vector3Int(0,-1), // ��
        new Vector3Int(1,0), // ��
        new Vector3Int(-1,0), // ��
    };
}