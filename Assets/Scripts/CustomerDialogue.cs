using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Customer))]
public class CustomerDialogue : MonoBehaviour
{
    TextMeshProUGUI _textMeshPro;
    CustomerEvents _customerEvents;
    Slider _slider;    
    RectTransform _rectTransform;
    Customer _customer;

    void Awake()
    {
        _customer = GetComponentInParent<Customer>();
        _customerEvents = GetComponentInParent<CustomerEvents>();
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _slider = GetComponentInChildren<Slider>();
        _rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        _customerEvents.onTransacting += BuyingText;
        _customerEvents.onTransacting += UpdateSlider;
        _customerEvents.onReWaiting += WaitingText;
        _customerEvents.onTransactionComplete += TransactonCompleteText;
        
        Vector3 rotateRect = new Vector3(_rectTransform.rotation.x, _customerEvents.transform.rotation.y , _rectTransform.rotation.z);
        _rectTransform.rotation = Quaternion.Euler(rotateRect); 

        
    }

    void WaitingText()
    {
        _textMeshPro.text = "Waiting";
        UpdateSlider();
    }

    void BuyingText()
    {
        _textMeshPro.text = "Buying";
    }

    void TransactonCompleteText()
    {
        _textMeshPro.text = "Thank you!";
    }

    void UpdateSlider()
    {
        Debug.Log(_customer._buyCounter + "SDSd");
        _slider.value = _customer._buyCounter/_customer._buyTime;
    }

    void OnDestroy()
    {
        _customerEvents.onTransacting -= BuyingText;
        _customerEvents.onTransacting -= UpdateSlider;
        _customerEvents.onReWaiting -= WaitingText;
        _customerEvents.onTransactionComplete -= TransactonCompleteText;
    }
}
