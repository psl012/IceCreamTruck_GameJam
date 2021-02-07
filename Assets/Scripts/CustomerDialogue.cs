using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerDialogue : MonoBehaviour
{
    TextMeshProUGUI _textMeshPro;
    Customer _customer;
    Slider _slider;


    void Awake()
    {
        _customer = GetComponentInParent<Customer>();
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _slider = GetComponentInChildren<Slider>();
    }

    void Start()
    {
        _customer.onBuying += BuyingText;
        _customer.onReWaiting += WaitingText;
        _customer.onTransactionComplete += TransactonCompleteText;
        _customer.onTransacting += UpdateSlider;
    }

    void WaitingText()
    {
        _textMeshPro.text = "Waiting";
        UpdateSlider(0);
    }

    void BuyingText()
    {
        _textMeshPro.text = "Buying";
    }

    void TransactonCompleteText()
    {
        _textMeshPro.text = "Thank you!";
    }

    void UpdateSlider(float timeValue)
    {
        _slider.value = timeValue;
    }

    void OnDestroy()
    {
        _customer.onBuying -= BuyingText;
        _customer.onReWaiting -= WaitingText;
        _customer.onTransactionComplete -= TransactonCompleteText; 
    }
}
