using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;

    private bool isActive = false;

    private void Start()
    {
        transform.position = startPosition.position;   
    }
    private void Update()
    {
        if (isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, Time.deltaTime);
        }
    }
    public void ActivarLava() 
    {
        isActive = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
