using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaulController : MonoBehaviour
{

    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }
    public void OpenBaul(){
        animator.SetBool("isChestOpen", true);
    }
}
