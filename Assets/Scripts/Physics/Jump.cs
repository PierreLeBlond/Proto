using UnityEngine;
using System.Collections;

enum Phase {
    SLEEPING = 0,
    GOINGUP = 1,
    GOINDOWN = 2
}

public class Jump : Control {

    public int                  maxJump = 1;

    public float                speed = 4.0f;
    public float                minHight = 2.0f;
    public float                maxHight = 8.0f;

    public float                gravity = -9.81f;

    public float                minHalfDistance = 1.0f;
    public float                maxHalfDistance = 3.0f;
    public float                fallHalfDistance = 2.0f;

    private int                 _nbJump = 0;
    private Phase               _phase = Phase.SLEEPING;
    private float               _currentGravity;

    public override void Init() {
        //_currentGravity = gravity;
        Break();
        body.GetComponent<Gravity>().enabled = false;
        body.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void Launch() {
        _nbJump++;
        _phase = Phase.GOINGUP;
        _currentGravity = getGravity(maxHight, speed, maxHalfDistance);
        body.velocity = getInitialVerticalSpeed(maxHight, speed, maxHalfDistance)*body.transform.up*body.transform.lossyScale.y;
    }

    public void Break() {
        _currentGravity = getGravity(minHight, speed, minHalfDistance);
    }

    public float getInitialVerticalSpeed(float hight, float horizontalSpeed, float halfDistance) {
        return (2.0f*hight*horizontalSpeed)/halfDistance;
    }

    public float getGravity(float hight, float horizontalSpeed, float halfDistance) {
        return (-2.0f*hight*horizontalSpeed*horizontalSpeed)/(halfDistance*halfDistance);
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
            Debug.Log("going down");
            _phase = Phase.GOINDOWN;
            _currentGravity = getGravity(maxHight, speed, fallHalfDistance);
        }
        else if(_phase == Phase.GOINDOWN && body.transform.localPosition.y <= -3.1f)
        {
            Debug.Log("idle");
            _phase = Phase.SLEEPING;
            _nbJump = 0;
        }
    }

    public void FixedUpdate () {
        //Apply custom gravity
        body.AddForce(body.transform.up * body.transform.lossyScale.y * _currentGravity);
    }
}
