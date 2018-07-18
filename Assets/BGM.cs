using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {

    AudioSource audioSource;
    [SerializeField]
    AudioClip bgm;
    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(bgm, 0.7f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
