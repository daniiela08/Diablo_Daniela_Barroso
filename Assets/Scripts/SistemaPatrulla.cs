using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Enemigo main;

    [SerializeField] private Transform ruta;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadPatrulla;

    private List<Vector3> listaPuntos = new List<Vector3>();
    private int indiceDestinoActual = -1;
    private Vector3 destinoActual;
    private void Awake()
    {
        main.Patrulla = this;

        foreach (Transform punto in ruta)
        {
            listaPuntos.Add(punto.position);
        }
    }
    private void OnEnable()
    {
        agent.stoppingDistance = 0;
        agent.speed = velocidadPatrulla;
        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        while (true)
        {
            CalcularDestino();
            agent.SetDestination(destinoActual);

            yield return new WaitUntil(() => agent.remainingDistance <= 0);

            yield return new WaitForSeconds(Random.Range(0.25f, 2f));
        }
    }

    private void CalcularDestino()
    {
        indiceDestinoActual++;
        if(indiceDestinoActual >= listaPuntos.Count)
        {
            indiceDestinoActual = 0;
        }
        destinoActual = listaPuntos[indiceDestinoActual];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            main.ActivarCombate(other.transform);
        }
    }
}
