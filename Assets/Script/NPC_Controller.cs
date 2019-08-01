using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NPC_Controller : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    float fieldOfView = 20f;

    [SerializeField]
    public bool friendIsWaving;

    [SerializeField]
    bool hasWaved = false;

    [SerializeField]
    float waveDuration = 10f;

    [SerializeField]
    GameObject fParticle;

    //Cooldown timer
    public float coolDown = 5;
    public float coolDownTimer;


    void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }
        FriendCheck();
    }

    private void FriendCheck()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;
        float angle = Vector3.Angle(targetDir, forward);
        if (angle < fieldOfView)
        {
            
            if (Player_Control.waving)
            {
                StartCoroutine(FriendWave());
                if (hasWaved == false && coolDownTimer == 0)
                {
                    GameObject clone = (GameObject)Instantiate(fParticle, gameObject.transform.position, gameObject.transform.rotation);
                    Destroy(clone, 1.0f);
    
                    hasWaved = true;

                    coolDownTimer = coolDown;
                }
            }
        }
    }

    private IEnumerator FriendWave()
    {
        friendIsWaving = true;

        yield return new WaitForSeconds(waveDuration);

        friendIsWaving = false;
        hasWaved = false;
    }
}
