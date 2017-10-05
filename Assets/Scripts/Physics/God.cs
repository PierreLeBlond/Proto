using UnityEngine;
using System;
using System.Collections;


public class God : Control {

    private Vector2         _target;
    private float           _mass = 1.0f;
    private float           _slope = 10.0f;
    private float           _drag = -2.0f;

    private Player          _player;

    public God(Rigidbody2D body, Player player) : base(body){
        _player = player;
    }

    public override void Init()
    {
        _body.gravityScale = 0.0f;
        _body.velocity = new Vector2(0.0f, 0.0f);
        _target = new Vector2(0.0f, 0.0f);
    }

    public override void Update() {
        if(Input.GetKey(Define.Key))
        {
            float y = (Input.mousePosition.y*10.0f)/Screen.height - 5.0f;
            float x = (Input.mousePosition.x*18.0f)/Screen.width - 9.0f;

            RaycastHit2D hit = Physics2D.GetRayIntersection(new Ray(new Vector3(x, y, 1),
                                                                    new Vector3(0, 0, -1)));

            if(hit)
            {
                if(hit.collider.CompareTag("Collectable"))
                    hit.collider.GetComponent<Collectable>().Activate(_player);
            }

            //_target = new Vector2(_body.position.x, y);
        }

        float distance = _target.y - _body.position.y;
        float thrust = _slope * distance;

        //Physics is awesome !
        _body.AddForce(new Vector3(0.0f, thrust));
        _body.AddForce(_drag * _body.velocity);
    }
}
