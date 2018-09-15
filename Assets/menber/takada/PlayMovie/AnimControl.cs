using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour {


    [SerializeField] private Animator _animator;


	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("AnimStart");
        }
	}
}
