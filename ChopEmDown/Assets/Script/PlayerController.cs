using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private bool isCut  = false;
    private bool isDead = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        animator.SetBool("isCut", isCut);
        animator.SetBool("isDead", isDead);

    }

    public void EnableCutAnimation()
    {
        isCut = true;
        isDead = false;
    }
    public void DisableCutAnimation()
    {
        isCut = false;
        isDead = false;
    }

    public void Dead()
    {
        isDead = true;
    }
    public void Respawn()
    {
        isDead = false;
    }
}
