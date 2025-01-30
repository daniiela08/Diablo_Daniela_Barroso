using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogoSO miDialogo;
    [SerializeField] private float duracionRotacion;
    [SerializeField] private Transform cameraPoint;
    void Start()
    {

    }
    void Update()
    {

    }
    public void Interactuar(Transform interactuador)
    {
        //rota hacia el interactuador y cuando termine se inicia la interaccion.
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(EmpezarInteraccion);
    }
    private void EmpezarInteraccion()
    {
        SistemaDialogo.System.StartDialogue(miDialogo, cameraPoint);
    }
}
