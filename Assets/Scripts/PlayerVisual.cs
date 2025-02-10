using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Player mainScript;
    [SerializeField] NavMeshAgent agent;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mainScript.PlayerVisual = this;
    }
    void Update()
    {
        anim.SetFloat("Velocity", agent.velocity.magnitude / agent.speed);
    }
    private void MakeAttack()
    {
        mainScript.Attack();
    }
    public void StartAttacking()
    {
        anim.SetBool("IsAttacking", true);
    }
    public void StopAttacking()
    {
        anim.SetBool("IsAttacking", false);
    }
    public void DeathAnim()
    {
        anim.SetTrigger("Death");
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(3);
    }
}
