using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour, IIDamagable
{
    [SerializeField] private float vidas;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float DanioAtaque;
    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private Image healthBar;

    private Camera cam;
    private NavMeshAgent agent;
    //ultimo sitio dnd cliqué con el raton.
    private Transform ultimoClick;

    private Transform objetivoActual;
    private PlayerVisual playerVisual;

    private float vidasActuales;

    public PlayerVisual PlayerVisual { get => playerVisual; set => playerVisual = value; }

    private void Awake()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        vidasActuales = vidas;
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
        if (ultimoClick)
        {
            playerVisual.StopAttacking();
            //si hay ultimo hit y tiene el script npc.
            if (ultimoClick.TryGetComponent(out IInteractable interactable))
            {
                //actualiza distancia de parada.
                agent.stoppingDistance = distanciaInteraccion;
                //si hemos llegado al destino.
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    interactable.Interact(transform);
                    //borramos el historial del ultimo click
                    ultimoClick = null;
                }
            }
            //si no es un npc
            else if (ultimoClick.TryGetComponent(out IIDamagable damage))
            {
                objetivoActual = ultimoClick;
                agent.stoppingDistance = distanciaAtaque;
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    playerVisual.StartAttacking();
                }
            }
            else
            {
                agent.stoppingDistance = 0;
            }
        }
    }
    public void Attack()
    {
        if(objetivoActual != null)
        {
            objetivoActual.GetComponent<IIDamagable>().RecibirDanio(DanioAtaque);
        }
    }

    public void RecibirDanio(float enemyDanio)
    {
        vidasActuales -= enemyDanio;
        healthBar.fillAmount = vidasActuales / vidas;
        if (vidasActuales <= 0)
        {
            Destroy(this);
            playerVisual.DeathAnim();
        }
    }
} 
