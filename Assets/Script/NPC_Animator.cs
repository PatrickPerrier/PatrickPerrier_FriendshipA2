using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Animator : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private NPC_Controller npc;
    private void Start()
    {
        npc = GetComponent<NPC_Controller>();
    }

    private void LateUpdate()
    {
        if (npc.friendIsWaving)
        {
            Wave();
        }
        else
            animator.SetBool("Wave", false);
            //animator.SetTrigger("Wave");
    }

    private void Wave()
    {
        animator.SetBool("Wave", true);
        //animator.SetTrigger("Wave");
    }
}
