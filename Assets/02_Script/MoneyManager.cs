using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    public static int _wave = 0;

    [SerializeField] private TextMeshProUGUI _text;
    public int origin;

    private void Awake()
    {
        Instance = this;
        _text.text = origin.ToString();
    }

    public void SetMoney(int value)
    {
        origin = Int32.Parse(_text.text);
        _text.text = (origin += value).ToString();
    }

    public void SpendMoney(int value)
    {
        origin = Int32.Parse(_text.text);
        _text.text = (origin -= value).ToString();
    }
}
