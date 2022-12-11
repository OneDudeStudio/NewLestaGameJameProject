using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShower : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;


    private void Update()
    {
        if (_canvas.gameObject.activeInHierarchy)
        {
            Debug.Log("GOOOD");
            _canvas.transform.LookAt(Camera.main.transform);
        }
    }

    public void ShowCanvas()
    {
        _canvas.SetActive(true);
        
    }
    
    
}