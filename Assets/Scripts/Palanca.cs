using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour, IInteractable
{
    [SerializeField] private Lava lavaPalanca;
    private Animator anim;

    private bool isActivated = false;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Interact(Transform interactuador)
    {
        if (!isActivated)
        {
            isActivated = true;
            lavaPalanca.ActivarLava();
            anim.SetTrigger("Bajar");
        }
    }
}
