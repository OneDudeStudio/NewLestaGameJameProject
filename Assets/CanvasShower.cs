using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasShower : MonoBehaviour
{
    public UIController UIController;


    private void Awake()
    {
        UIController = FindObjectOfType<UIController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.TryGetComponent(out PlayerTopDownController playerTopDownController);
        if (playerTopDownController!= null)
        {
            UIController.SetCanvasActive(UIController._farmCanvas);
        }
        
    }
    
    private void OnCollisionExit(Collision collision)
    {
        UIController.SetCanvasDeactive(UIController._farmCanvas);
    }
}