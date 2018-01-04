using UnityEngine;
using System;
using System.Collections;

public class Rocket : Control {

    private Vector2         _target;
    private float           _slope = 10.0f;
    private float           _drag = -5.0f;

    public Rocket(Rigidbody body, BoxCollider mouseCollider) : base(body, mouseCollider){}

    public override void Init()
    {
        _body.useGravity = false;
        _body.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        _target = new Vector3(0.0f, 0.0f, 0.0f);
        _body.transform.localEulerAngles = new Vector3(0, 0, -90);
    }

    public override void Update() {
        if(Input.GetKey(Define.Key))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if(_mouseCollider.Raycast(ray, out raycastHit, 100.0f)) {
                Vector3 impact = raycastHit.point;
                Vector3 center = _mouseCollider.transform.position;
                Vector3 offset = impact - center;
                float y = offset.y / _mouseCollider.transform.lossyScale.y;
                _target = new Vector3(_body.transform.localPosition.x, y, _body.transform.localPosition.z);
            }
        }

        float distance = _target.y - _body.transform.localPosition.y;
        float thrust = _slope * distance;

        //Physics is awesome !
        _body.AddForce(_body.transform.right * -thrust);
        _body.AddForce(_drag * _body.velocity);
    }
}
