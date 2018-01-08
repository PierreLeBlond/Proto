using UnityEngine;
using System;
using System.Collections;


public class God : Control {

    private Vector2         _target;
    private float           _mass = 1.0f;
    private float           _slope = 10.0f;
    private float           _drag = -2.0f;

    private Player          _player;

    public God(Rigidbody body, BoxCollider mouseCollider, Player player) : base(body, mouseCollider){
        _player = player;
    }

    public override void Init()
    {
        _body.GetComponent<Gravity>().enabled = false;
        _body.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        _target = new Vector3(0.0f, 0.0f, 0.0f);
        _body.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public override void Update() {
        if(Input.GetKey(Define.Key))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool hasHit = Physics.Raycast(ray, out raycastHit);

            if(hasHit)
            {
                if(raycastHit.collider.CompareTag("Collectable")) {
                    raycastHit.collider.GetComponent<Collectable>().Activate(_player);
                }
            }
        }

        float distance = _target.y - _body.transform.localPosition.y;
        float thrust = _slope * distance;

        //Physics is awesome !
        _body.AddForce(_body.transform.up * thrust);
        _body.AddForce(_drag * _body.velocity);
    }
}
