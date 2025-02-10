using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour, IIDamagable
{
    [SerializeField] private float vidasIniciales;
    [SerializeField] private Image healthBar;
    [SerializeField] private AnimacionesEnemigo enemigoAnims;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Collider coll;

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;


    private SistemaCombate combate;
    private SistemaPatrulla patrulla;
    private Transform objetivo;

    private float vidasActuales;
    private bool isDeath;

    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform Objetivo { get => objetivo; set => objetivo = value; }

    private void Awake()
    {
        vidasActuales = vidasIniciales;
    }
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

    public void RecibirDanio(float enemyDanio)
    {
        if (isDeath)
        {
            return;
        }

        vidasActuales -= enemyDanio;
        healthBar.fillAmount = vidasActuales / vidasIniciales;

        if (vidasIniciales <= 0 || healthBar.fillAmount <= 0)
        {
            isDeath = true;
            Death();
        }
    }
    private void Death()
    {
        Destroy(canvas);
        Destroy(coll);
        Destroy(combate);
        Destroy(patrulla.gameObject);
        Destroy(gameObject, 3);
        enemigoAnims.DeathAnim();
    }
}
