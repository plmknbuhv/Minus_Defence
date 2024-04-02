using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        Instance = this;
    }

    public void SetMoney(int value)
    {
        int origin = Int32.Parse(_text.text);
        _text.text = (origin + value).ToString();
    }
}
