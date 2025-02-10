using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private MisionSO missionNPC;
    [SerializeField] private DialogoSO myDialogueBefore;
    [SerializeField] private DialogoSO myDialogueAfter;
    [SerializeField] private float rotateDuration;
    [SerializeField] private Transform cameraPoint; //punto camara de cada npc.

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;

    private DialogoSO actualDialogue;

    private void Awake()
    {
        actualDialogue = myDialogueBefore;
    }
    private void OnEnable()
    {
        eventManager.onNoMision += ChangeDialogue;
    }
    private void OnDisable()
    {
        eventManager.onNoMision -= ChangeDialogue;
    }
    private void ChangeDialogue(MisionSO missionFinish)
    {
        if (missionNPC == missionFinish)
        {
            actualDialogue = myDialogueAfter;
        }
    }

    private void StartInteraction()
    {
        SistemaDialogo.System.StartDialogue(actualDialogue, cameraPoint);
    }
    public void Interact(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, rotateDuration, AxisConstraint.Y).OnComplete(StartInteraction);
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
