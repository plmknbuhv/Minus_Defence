using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float maxHp = 100;
    public float curHp = 100;
    Transform _transform;

    private void Awake()
    {
        _transform = transform.Find("Pivot").transform;

        _transform.localScale = Vector3.one;
    }

    public void Hit()
    {
        curHp -= 20f;
        _transform.localScale = new Vector3(curHp / maxHp, 1, 1);
    }
}
