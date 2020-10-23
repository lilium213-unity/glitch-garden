using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    float currentSpeed;
    Coroutine slowRoutine;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void StartMoving()
    {
        currentSpeed = speed;
    }

    public void Slow(float timeInSeconds, float slowAmount)
    {
        if(slowRoutine == null)
            slowRoutine = StartCoroutine(SlowCoroutine(timeInSeconds, slowAmount));
        else
        {
            StopCoroutine(slowRoutine);
            slowRoutine = StartCoroutine(SlowCoroutine(timeInSeconds, slowAmount));
        }
    }

    private IEnumerator SlowCoroutine(float timeInSeconds, float slowAmount)
    {
        currentSpeed = speed - speed * slowAmount;
        yield return new WaitForSeconds(timeInSeconds);
        currentSpeed = speed;
    }
}
