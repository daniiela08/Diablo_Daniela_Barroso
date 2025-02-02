using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;

    private Transform objetivo;

    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform Objetivo { get => objetivo; set => objetivo = value; }

    void Start()
    {
        patrulla.enabled = true;
    }
    public void ActivarCombate(Transform objetivo)
    {
        this.objetivo = objetivo;

        combate.enabled = true;
    }
    public void ActivarPatrulla()
    {
        combate.enabled = true;
        patrulla.enabled = false;
    }
}
