using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    //ultimo sitio dnd cliqué con el raton.
    private Transform ultimoClick;
    [SerializeField] private float distanciaInteraccion;
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Movimiento();
        ComprobarInteraccion();
    }

    private void Movimiento()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                agent.SetDestination(hitInfo.point);
                ultimoClick = hitInfo.transform;
            }
        }
    }
    private void ComprobarInteraccion()
    {
        if (ultimoClick != null && ultimoClick.TryGetComponent(out NPC scriptNPC))
        {
            agent.stoppingDistance = distanciaInteraccion;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                scriptNPC.Interactuar(transform);
                ultimoClick = null;
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
    }
} 
