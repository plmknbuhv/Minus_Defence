using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    private float maxHp = 100;
    public float curHp = 100;
    Transform _transform;

    private void Awake()
    {
        _transform = transform.Find("Pivot").transform;

        _transform.localScale = Vector3.one;
    }

    public void PlayerHit()
    {
        curHp -= 20f;
        _transform.localScale = new Vector3((float)curHp / (float)maxHp, 1, 1);
        if (curHp <= 0 )
        {
            SceneManager.LoadScene(0);
        }    
    }
}
