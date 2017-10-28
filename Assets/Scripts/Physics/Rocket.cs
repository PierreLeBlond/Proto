using UnityEngine;
using System;
using System.Collections;

public class Rocket : Control {

    private Vector2         _target;
    private float           _mass = 1.0f;
    private float           _slope = 10.0f;
    private float           _drag = -2.0f;

    public Rocket(Rigidbody2D body) : base(body){}

    public override void Init()
    {
        _body.gravityScale = 0.0f;
        _body.velocity = new Vector2(0.0f, 0.0f);
        _target = new Vector2(0.0f, 0.0f);
        _body.transform.eulerAngles = new Vector3(0, 0, -90);
    }

    public override void Update() {
        if(Input.GetKey(Define.Key))
        {
            float y = (Input.mousePosition.y*10.0f)/Screen.height - 5.0f;
            _target = new Vector2(_body.position.x, y);
        }

        float distance = _target.y - _body.position.y;
        float thrust = _slope * distance;

        //Physics is awesome !
        _body.AddForce(new Vector3(0.0f, thrust));
        _body.AddForce(_drag * _body.velocity);
    }
}
