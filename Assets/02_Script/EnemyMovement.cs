using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.TerrainUtils;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private TileBase _tile;
    [SerializeField] private Vector3Int _beforeDirection;
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        _tilemap = GameObject.Find("Route").GetComponent<Tilemap>();
    }

    private void Start()
    {
        StartCoroutine(FindRoute());
    }

    private IEnumerator FindRoute() 
    {
        while (true) // ���� �ݺ���
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
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (dir == Directions.DIRECTIONS[1])
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                    else if (dir == Directions.DIRECTIONS[2])
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 270);
                    }
                    else if (dir == Directions.DIRECTIONS[3])
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                    }

                    transform.DOMove(tilepos, 1 / _moveSpeed).SetEase(Ease.Linear);
                    _beforeDirection = dir;
                    yield return new WaitForSeconds(1 / _moveSpeed);
                }
            }
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