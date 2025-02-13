using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractFinal : MonoBehaviour, IInteractable
{
    [SerializeField] private MisionSO mision;
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;
    public void Interact(Transform interactuador)
    {
        if (mision.repeticionActual >= mision.repeticionesTotales)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(interactIcon, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultIcon, Vector2.zero, CursorMode.Auto);
    }
}
