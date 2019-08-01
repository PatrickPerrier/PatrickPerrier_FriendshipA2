using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Control : MonoBehaviour
{
    [SerializeField]
    float acceleration = 10;

    [SerializeField]
    float maxSpeed = 7;

    [SerializeField]
    float minSpeed = 2;

    [SerializeField]
    float speedChangeInterval = 0.5f;

    [SerializeField]
    float waveDuration = 0.5f;

    //Cooldown timer
    public float coolDown = 10;
    public float coolDownTimer;

    private float currentTargetSpeed;
    public static bool waving;

    public float speedX;
    public float speedZ;
    public int turnDegrees = 2;
    


    public event Action OnWave;

    private void Awake()
    {

        currentTargetSpeed = minSpeed;
    }

    private void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        float moveInputZ = Input.GetAxisRaw("Vertical");
     
        speedZ = Mathf.MoveTowards(speedZ, currentTargetSpeed * moveInputZ, acceleration * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -turnDegrees, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, turnDegrees, 0));
        }

        Vector3 direction = new Vector3(0, 0, speedZ);

        if (!waving && Input.GetMouseButton(0) && coolDownTimer == 0)
        {
            StartCoroutine(Wave());
            coolDownTimer = coolDown;
        }

        transform.Translate(direction * Time.deltaTime);
    }

    private IEnumerator Wave()
    {
        if (OnWave != null)
        {
            OnWave();
        }

        waving = true;

        yield return new WaitForSeconds(waveDuration);

        waving = false;
    }
}
