using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo System;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField] private GameObject frameDialogo;

    [SerializeField] private Transform npcCamara;

    private bool escribiendo;
    private int indiceFraseActual = 0;

    private DialogoSO dialogoActual;

    [SerializeField] private EventManagerSO eventmanager;
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
    public void StartDialogue(DialogoSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0;
        dialogoActual = dialogo;
        frameDialogo.SetActive(true);
        npcCamara.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
        StartCoroutine(EscribirFrase());
    }

    private IEnumerator EscribirFrase()
    {
        escribiendo = true;

        textoDialogo.text = string.Empty;

        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();

        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;

            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }
        escribiendo = false;
    }
    private void CompletarFrase()
    {
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        StopAllCoroutines();
        escribiendo = false;
    }
    public void SiguienteFrase()
    {
        if (!escribiendo)
        {
            indiceFraseActual++;

            if (indiceFraseActual < dialogoActual.frases.Length)
            {
                StartCoroutine(EscribirFrase());
            }
            else
            {
                AcabarDialogo();
            }
        }
        else
        {
            CompletarFrase();
        }
    }

    private void AcabarDialogo()
    {
        Time.timeScale = 1;
        frameDialogo.SetActive(false);
        indiceFraseActual = 0;

        if (dialogoActual.tieneMision)
        {
            eventmanager.NuevaMision(dialogoActual.mision);
        }

        dialogoActual = null;
    }
}
