using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    [SerializeField]
    private Material transparentWall;

    [SerializeField]
    private Material opaqueWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo")) 
        {
            other.GetComponent<MeshRenderer>().material = transparentWall;
            Material currentMaterial = other.GetComponent<MeshRenderer>().material;

            Color transparente = new Color(currentMaterial.color.r, currentMaterial.color.g, currentMaterial.color.b, 0f);

            currentMaterial.DOColor(transparente, 1f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            other.GetComponent<MeshRenderer>().material = opaqueWall;
            Material currentMaterial = other.GetComponent<MeshRenderer>().material;

            Color opaco = new Color(currentMaterial.color.r, currentMaterial.color.g, currentMaterial.color.b, 1f);

            currentMaterial.DOColor(opaco, 1f);
        }
    }
}
