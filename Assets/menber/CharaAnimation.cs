using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAnimations : MonoBehaviour
{
    
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AttackAnimation()
    {
        animator.SetBool("Attack",true);
    }

    public void DamegeAnimation()
    {
        animator.SetFloat("MoveSpeed", 0.0f);
        animator.SetBool("Damage", true);
        animator.SetFloat("MoveSpeed", 1.0f);
    }
    public void AttackEffect(string name)
    {

        var obj = (GameObject)Resources.Load("Prefabs/Light_bool");
        
        switch (name)
        {
            case "datyo":
                obj = Instantiate(obj, new Vector2(4, 3), Quaternion.identity);
                animator = GetComponent<Animator>();
                animator.SetBool("datyo", true);
                break;
            case "tokage":
                obj = Instantiate(obj, new Vector2(5.05f, 1.47f), Quaternion.identity);
                animator = GetComponent<Animator>();
                animator.SetBool("tokage", true);
                break;
            case "momonga":
                obj = Instantiate(obj, new Vector2(3.72f, -0.44f), Quaternion.identity);
                animator = GetComponent<Animator>();
                animator.SetBool("momonga", true);
                break;
            case "kame":
                obj = Instantiate(obj, new Vector2(5.19f, -1.6f), Quaternion.identity);
                animator = GetComponent<Animator>();
                animator.SetBool("kame", true);
                break;
            case "tinpan":
                obj = Instantiate(obj, new Vector2(-5, 1), Quaternion.identity);
                animator = GetComponent<Animator>();
                animator.SetBool("tinpan", true);
                break;
        }
        
    }
}
