using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardWalker : MonoBehaviour
{
    //Refrences
    [SerializeField] private Rigidbody2D wb;
    [SerializeField] private Animator wizardAnimator;

    //Editable Fields
    [SerializeField] private float speedX, speedY;
    [SerializeField] private float patrolX, patrolUp, patrolDown; //Max Dist from X, Y to origin
    [SerializeField] private bool goY = false; //Toggle Y movement

    //Pause/ Walk time controllers
    private float randomTimeX, timerX;
    private float randomTimeY, timerY;

    private float minPauseTimeX = 1, maxPauseTimeX = 2;
    private float minWalkTimeX = 3, maxWalkTimeX = 4;

    private float minPauseTimeY = 1, maxPauseTimeY = 2;
    private float minWalkTimeY = 3, maxWalkTimeY = 4;

    //Walking Direction controls
    private bool isWalkingX = false;
    private bool isWalkingY = false;
    private bool isFlippingX = false;
    private bool isFlippingY = false;
    private int risingDirection = 1;
    private int facingDirection = 1;
    private Vector2 motionVector = new Vector2(0.0f, 0.0f);

    //Called On Start
    private void Start()
    {
        randomTimeX = UnityEngine.Random.Range(minWalkTimeX, maxWalkTimeX);
        randomTimeY = UnityEngine.Random.Range(minWalkTimeY, maxWalkTimeY);
    }

    // Update is called once per frame
    void Update()
    {
        timerX += Time.deltaTime;
        timerY += Time.deltaTime;

        if (timerX >= randomTimeX) {
            StateChangeX();
        }

        if (timerY >= randomTimeY) {
            StateChangeY();
        }

        if (!isFlippingX && Math.Abs(transform.position.x) >= patrolX) {
            StartCoroutine(FlipX());
        }

        if (!isFlippingY && (Math.Abs(transform.position.y) >= patrolDown || transform.position.y >= patrolUp) && goY) {
            StartCoroutine(FlipY());
        }

        if (isWalkingX) {
            motionVector += Vector2.right * speedX  * facingDirection;
        }

        if (isWalkingY && goY) {
            motionVector += Vector2.up * speedY * risingDirection;
        }

        if (isWalkingX || isFlippingY) {
            wizardAnimator.SetBool("isWalking", true);
        } else {
            wizardAnimator.SetBool("isWalking", false);
        }

        wb.velocity = motionVector;
        motionVector *= 0;
    }

    IEnumerator FlipX() {
        isFlippingX = true;
        transform.Rotate(0, 180, 0);
        facingDirection *= -1;
        yield return new WaitForSeconds(0.5f);
        isFlippingX = false;
    }

    IEnumerator FlipY() {
        isFlippingY = true;
        risingDirection *= -1;
        yield return new WaitForSeconds(0.5f);
        isFlippingY = false;
    }

    void StateChangeX() {
        isWalkingX = !isWalkingX;
        randomTimeX = isWalkingX ? UnityEngine.Random.Range(minWalkTimeX, maxWalkTimeX) : UnityEngine.Random.Range(minPauseTimeX, maxPauseTimeX);
        timerX = 0;
    }

    void StateChangeY() {
        isWalkingY = !isWalkingY;
        randomTimeY = isWalkingY ? UnityEngine.Random.Range(minWalkTimeY, maxWalkTimeY) : UnityEngine.Random.Range(minPauseTimeY, maxPauseTimeY);
        timerY = 0;
    }
}

