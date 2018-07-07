using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    Animator anim;
    public GameObject player;


	void Start () {
        anim = gameObject.GetComponent<Animator>();
        
	}
	
	void Update () {
        Bounce bounceScript = player.GetComponent<Bounce>();
        if (bounceScript.justJump == true) {
            anim.SetBool("jump", true);
        } else {
            anim.SetBool("jump", false);
        }
	}
}
