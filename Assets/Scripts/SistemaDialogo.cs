using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo System;
    void Awake()
    {
        if (System == null)
        {
            System = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
    public void StartDialogue(DialogoSO dialogo)
    {

    }
}
