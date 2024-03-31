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
        while (true) // 무한 반복문
        {
            yield return null; // 아무 것도 리턴하지 않으면 빠르게 반복해 터지니까 한틱씩 리턴

            if (Input.GetKeyDown(KeyCode.F12)) // 만약 f12를 누르면 
                break; // 코드 탈출

            foreach (var dir in Directions.DIRECTIONS) // 방향 배열을 반복
            {
                Vector3Int tilepos = _tilemap.WorldToCell(transform.position); // Enemy의 위치를 Vector3Int로 바꿔 저장
                tilepos += dir; // 상, 하, 좌, 우 4방향의 타일을 체크

                var tile = _tilemap.GetTile(tilepos); // 체크한 타일을 저장

                if (tile != null) // 타일이 있다면
                {
                    if (dir == -_beforeDirection) continue; // 내가 왔던 길의 타일이라면 스킵

                    /*각 이동 방향별로 Enemy의 방향 전환*/
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

class Directions // 방향을 담을 방향 클래스 선언
{
    public static Vector3Int[] DIRECTIONS = new Vector3Int[] // static으로 Vector3Int형의 배열 생성
    {
        new Vector3Int(0,1), // 상
        new Vector3Int(0,-1), // 하
        new Vector3Int(1,0), // 좌
        new Vector3Int(-1,0), // 우
    };
}