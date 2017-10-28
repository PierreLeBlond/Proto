using UnityEngine;
using System;
using System.Collections;


public class Jetpack : Control {

    private float               _thrust = 2.0f;

    public Jetpack(Rigidbody2D body) : base(body){}

    public override void Init()
    {
        _body.gravityScale = 1.0f;
        _body.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public override void Update() {
        if(Input.GetKey(Define.Key))
            _body.AddForce(Vector2.up * _thrust);
    }
}
