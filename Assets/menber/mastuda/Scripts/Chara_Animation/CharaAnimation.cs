
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAnimation : MonoBehaviour
{
    Animator animator;
    GameObject effect;
    GameObject datyo;
    GameObject tokage;
    GameObject momonga;
    GameObject kame;
    GameObject tinpan;
    // Use this for initialization
    void Start()
    {
        effect = GameObject.Find("Effect");
        animator = GetComponent<Animator>();
    }

    public void AttackAnimation()
    {
        animator.SetBool("Attack", true);
    }

    public void DamegeAnimation()
    {
        animator.SetBool("Damage", true);
    }
    public void AttackEffect(string name)
    {
        switch (name)
        {
            case "datyo":
                //InstantEffect("Datyo", datyo);
                
                datyo = (GameObject)Resources.Load("Prefabs/Datyo_Effect");
                datyo = Instantiate(datyo, new Vector2(4, 3), Quaternion.identity);
                animator = GetComponent<Animator>();
                Invoke("DelayDestroyDatyo", 0.5f);
                
                break;
            case "tokage":
                //InstantEffect("Tokage", tokage);
                
                tokage = (GameObject)Resources.Load("Prefabs/Tokage_Effect");
                tokage = Instantiate(tokage, new Vector2(5.05f, 1.47f), Quaternion.identity);
                animator = GetComponent<Animator>();
                //0.5秒のディレイを作るメソッド
                Invoke("DelayDestroyTokage", 0.5f);
                
                break;
            case "momonga":
                //InstantEffect("Momonga", momonga);
                
                momonga = (GameObject)Resources.Load("Prefabs/Momonga_Effect");
                momonga = Instantiate(momonga, new Vector2(3.72f, -0.44f), Quaternion.identity);
                animator = GetComponent<Animator>();
                Invoke("DelayDestroyMomonga", 0.5f);
                
                break;
            case "kame":
                //InstantEffect("Kame", kame);
                
                kame = (GameObject)Resources.Load("Prefabs/Kame_Effect");
                kame = Instantiate(kame, new Vector2(5.19f, -1.6f), Quaternion.identity);
                animator = GetComponent<Animator>();
                Invoke("DelayDestroyKame", 0.5f);
                
                break;
            case "tinpan":
                //InstantEffect("Tinpan", tinpan);

                if (GameObject.Find("Tinpan_Effect(Clone)") == false)
                {
                    tinpan = (GameObject)Resources.Load("Prefabs/Tinpan_Effect");
                    tinpan = Instantiate(tinpan, new Vector2(-5, 1), Quaternion.identity);
                    animator = GetComponent<Animator>();
                    Invoke("DelayDestroyTinpan", 0.5f);
                }
                break;
        }
        
    }
    private GameObject InstantEffect(string name,GameObject obj)
    {
        obj = (GameObject)Resources.Load("Prefabs/" + name + "_Effect");
        obj = Instantiate(obj, new Vector2(0,0), Quaternion.identity);
        animator = GetComponent<Animator>();
        return obj;
    }
    private void DelayDestroyDatyo()
    {
        Destroy(datyo);
    }
    private void DelayDestroyTokage()
    {
        Destroy(tokage);
    }
    private void DelayDestroyMomonga()
    {
        Destroy(momonga);
    }
    private void DelayDestroyKame()
    {
        Destroy(kame);
    }
    private void DelayDestroyTinpan()
    {
        Destroy(tinpan);
    }
}
    
