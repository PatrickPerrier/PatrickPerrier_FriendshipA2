using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private Player_Control character;

    private void Awake()
    {
        character = GetComponent<Player_Control>();

        character.OnWave += PlayerControler_OnWave;
    }

    private void PlayerControler_OnWave()
    {
        animator.SetTrigger("Wave");
    }

    private void LateUpdate()
    {
        animator.SetFloat("Speed", character.speedZ);
    }
}
