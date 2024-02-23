using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private int currencyValue;

    public int GetCurrencyValue()
    {
        return currencyValue;
    }
    
    public void AddCurrency(int value)
    {
        currencyValue += value;
        currencyText.text = currencyValue.ToString();
    }

    public void RemoveCurrency(int value)
    {
        currencyValue -= value;
        currencyText.text = currencyValue.ToString();
    }
}