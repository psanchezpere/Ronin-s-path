using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaulController : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private float condition;

    private StoryController storyController;

    private void Start(){
        animator = GetComponent<Animator>();
        storyController = GameObject.Find("StoryController").GetComponent<StoryController>();
        if(storyController.CheckSecondaryMission(condition) || storyController.CheckMainMission(condition)){
            animator.SetBool("isChestOpen", true);
        }
    }
    public void OpenBaul(){
        animator.SetBool("isChestOpen", true);
    }


}
