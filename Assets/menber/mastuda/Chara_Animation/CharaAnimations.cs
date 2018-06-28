using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAnimations : MonoBehaviour
{

    Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AttackAnimation()
    {
        animator.SetBool("Attack",true);
    }
}
