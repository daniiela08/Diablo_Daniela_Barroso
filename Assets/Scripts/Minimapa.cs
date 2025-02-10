using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimapa : MonoBehaviour
{
    [SerializeField] private Player Player;

    private Vector3 distanceToPlayer;
    void Start()
    {
        distanceToPlayer = transform.position - Player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = Player.transform.position + distanceToPlayer;
    }
}
