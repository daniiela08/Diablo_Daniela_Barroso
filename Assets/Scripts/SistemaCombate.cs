using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private Animator anim;
    private void Awake()
    {
        main.Combate = this;
    }
    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }
    void Update()
    {
        if(main.Objetivo != null && agent.CalculatePath(main.Objetivo.position, new NavMeshPath()))
        {
            EnfocarObjetivo();

            agent.SetDestination(main.Objetivo.position);
            if(!agent.pathPending && agent.remainingDistance <= distanciaAtaque)
            {
                anim.SetBool("Atacando", true);
            }
        }
        else
        {
            main.ActivarPatrulla();
        }
    }

    private void EnfocarObjetivo()
    {
        Vector3 direccionObjetivo = (main.Objetivo.position - transform.position).normalized;
        direccionObjetivo.y = 0;
        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionObjetivo);
        transform.rotation = rotacionObjetivo;
    }
}
