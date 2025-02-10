using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Libro : MonoBehaviour, IInteractable
{
    private Outline Outline;

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;

    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private MisionSO mision;


    private void Awake()
    {
        Outline = GetComponent<Outline>();
    }
    public void Interact(Transform interactuador)
    {
        mision.repeticionActual++;

        if(mision.repeticionActual < mision.repeticionesTotales)
        {
            eventManager.ActualizarMision(mision);
        }
        else
        {
            eventManager.FinMision(mision);
        }
        Destroy(gameObject);
    }
    private void OnMouseEnter()
    {
        Outline.enabled = true;
        Cursor.SetCursor(interactIcon, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Outline.enabled = false;
        Cursor.SetCursor(defaultIcon, Vector2.zero, CursorMode.Auto);
    }
}
