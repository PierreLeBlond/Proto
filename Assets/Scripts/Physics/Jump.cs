using UnityEngine;
using System;
using System.Collections;

enum Phase {
    SLEEPING = 0,
    GOINGUP = 1,
    GOINDOWN = 2
}

public class Jump : Control {

    public int                  maxJump = 2;

    //Horizontal speed of the player
    public float                footSpeed = 4.0f;

    public float                minHight = 1.0f;
    public float                maxHight = 14.0f;

    public float                gravity = -9.81f;

    public float                minHalfDistance = 2.0f;
    public float                fallHalfDistance = 3.0f;
    public float                maxHalfDistance = 8.0f;
    public bool                 timeBased = true;
    public float                minHalfTime = 1.0f;
    public float                fallHalfTime = 3.0f;
    public float                maxHalfTime = 2.0f;


    private int                 _nbJump = 0;
    private Phase               _phase = Phase.SLEEPING;
    private float               _currentGravity;

    private float               _groundPosition;

    public override void Init() {
        //_currentGravity = gravity;
        Break();
        _phase = Phase.GOINDOWN;
        body.GetComponent<Gravity>().enabled = false;
        body.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void Launch() {
        _nbJump++;
        _phase = Phase.GOINGUP;
        _currentGravity = getGravity(maxHight, footSpeed, maxHalfDistance, maxHalfTime);
        body.velocity = getInitialVerticalSpeed(maxHight, footSpeed, maxHalfDistance, maxHalfTime)*body.transform.up;
    }

    public void Break() {
        //_currentGravity = getGravity(minHight, footSpeed, minHalfDistance);
        float relativePosition = body.transform.localPosition.y - _groundPosition;
        float distanceToMaxPeak = maxHight - relativePosition;
        float distanceToPeak = Math.Max(0.1f, Math.Min(minHight, distanceToMaxPeak));
        _currentGravity = getBreakGravity(body.velocity.y, distanceToPeak);
    }



    public float getInitialVerticalSpeed(float hight, float horizontalSpeed, float halfDistance, float halfTime) {
        if(timeBased) {
            return getInitialVerticalSpeedByTime(hight*body.transform.lossyScale.y, halfTime);
        } else {
            return getInitialVerticalSpeedByDirection(hight*body.transform.lossyScale.y, horizontalSpeed, halfDistance*body.transform.lossyScale.y);
        }
    }

    public float getInitialVerticalSpeedByTime(float hight, float halfTime) {
        return (2.0f*hight)/halfTime;
    }

    public float getInitialVerticalSpeedByDirection(float hight, float horizontalSpeed, float halfDistance) {
        return (2.0f*hight*horizontalSpeed)/halfDistance;
    }

    public float getGravity(float hight, float horizontalSpeed, float halfDistance, float halfTime) {
        if(timeBased) {
            return getGravityByTime(hight*body.transform.lossyScale.y, halfTime);
        } else {
            return getGravityByDistance(hight*body.transform.lossyScale.y, horizontalSpeed, halfDistance*body.transform.lossyScale.y);
        }
    }

    public float getGravityByTime(float hight, float halfTime) {
        return (-2.0f*hight)/(halfTime*halfTime);

    }

    public float getGravityByDistance(float hight, float horizontalSpeed, float halfDistance) {
        return (-2.0f*hight*horizontalSpeed*horizontalSpeed)/(halfDistance*halfDistance);
    }

    public float getBreakGravity(float verticalSpeed, float hight) {
        return -(verticalSpeed * verticalSpeed) / (2.0f * hight * body.transform.lossyScale.y);
    }

    public void Update() {
        if(Input.GetKeyDown(Define.Key) && _nbJump < maxJump)
        {
            Launch();
        }
        else if(Input.GetKeyUp(Define.Key) && _phase == Phase.GOINGUP)
        {
            Break();
        }

        if(_phase == Phase.GOINGUP && body.velocity.y < 0)
        {
            _phase = Phase.GOINDOWN;
            _currentGravity = getGravity(maxHight, footSpeed, fallHalfDistance, fallHalfTime);
        }
        else if(_phase == Phase.GOINDOWN && body.transform.localPosition.y < -3.9)
        {
            _phase = Phase.SLEEPING;
            _nbJump = 0;
            _groundPosition = body.transform.localPosition.y;
        }
    }

    public void FixedUpdate () {
        //Apply custom gravity
        body.AddForce(body.transform.up * _currentGravity);
    }
}
