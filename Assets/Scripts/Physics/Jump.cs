using UnityEngine;
using System.Collections;

enum Phase {
    SLEEPING = 0,
    GOINGUP = 1,
    GOINDOWN = 2
}

public class Jump : Control {

    public int                  maxJump = 1;

    public float                speed = 3.0f;
    public float                minHight = 2.0f;
    public float                maxHight = 6.0f;

    public float                gravity = -9.81f;

    public float                minHalfDistance = 1.0f;
    public float                maxHalfDistance = 3.0f;
    public float                fallHalfDistance = 2.0f;

    private int                 _nbJump = 0;

    private Phase               _phase = Phase.SLEEPING;

    public Jump(Rigidbody2D body) : base(body) {}

    public override void Init() {
        _body.gravityScale = 1.0f;
        _body.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void Launch() {
        _nbJump++;
        _phase = Phase.GOINGUP;
        _body.gravityScale = getGravity(maxHight, speed, maxHalfDistance)/gravity;
        _body.velocity = new Vector3(0.0f, getInitialVerticalSpeed(maxHight, speed, maxHalfDistance), 0.0f);
    }

    public void Break() {
        _body.gravityScale = getGravity(minHight, speed, minHalfDistance)/gravity;
    }

    public float getInitialVerticalSpeed(float hight, float horizontalSpeed, float halfDistance) {
        return (2.0f*hight*horizontalSpeed)/halfDistance;
    }

    public float getGravity(float hight, float horizontalSpeed, float halfDistance) {
        return (-2.0f*hight*horizontalSpeed*horizontalSpeed)/(halfDistance*halfDistance);
    }

    public override void Update() {
        if(Input.GetKeyDown(Define.Key) && _nbJump < maxJump)
        {
            Launch();
        }
        else if(Input.GetKeyUp(Define.Key) && _phase == Phase.GOINGUP)
        {
            Break();
        }

        if(_phase == Phase.GOINGUP && _body.velocity.y < 0)
        {
            _phase = Phase.GOINDOWN;
            _body.gravityScale = getGravity(maxHight, speed, fallHalfDistance)/gravity;
        }
        else if(_phase == Phase.GOINDOWN && _body.position.y <= -2.8f)
        {
            _phase = Phase.SLEEPING;
            _nbJump = 0;
        }
    }
}

