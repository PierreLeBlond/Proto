using UnityEngine;
using System;
using System.Collections;

public static class Define {

    public const string Key = "mouse 0";
}

public class PlayerState {

    protected Rigidbody2D _body;
    protected ParticleSystem _particles;

    public PlayerState(Rigidbody2D body)
    {
        _body = body;
    }

    public void SetParticleSystem(ParticleSystem particles)
    {
        _particles = particles;
    }

    public virtual void Init() {
    }

    public virtual void Update() {
    }
}

public class PlayerJumpState : PlayerState {

    private int              _numberOfJump = 0;
    private int              _jumpLength = 0;
    private float            _thrust = 5.0f;

    public PlayerJumpState(Rigidbody2D body) : base(body){}

    public override void Init()
    {
        _body.gravityScale = 1.0f;
        _particles.transform.localPosition = new Vector3(0.0f, -0.5f, -1.0f);
        _particles.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        _particles.Stop();
    }

    public override void Update() {
        if(Input.GetKeyDown(Define.Key) && _numberOfJump < 2)
        {
            _body.velocity = new Vector3(0.0f, _thrust, 0.0f);
            _particles.Play();
        }
        else if(Input.GetKeyUp(Define.Key))
        {
            _jumpLength = 0;
            _numberOfJump++;
            _particles.Stop();
        }
        else if(Input.GetKey(Define.Key) && _jumpLength < 20 && _numberOfJump < 2)
        {
            _jumpLength++;
            _body.velocity = new Vector3(0.0f, _thrust, 0.0f);
        }
        else if(_body.position.y <= -3.4f)
            _numberOfJump = 0;
    }
}

public class PlayerJetpackState : PlayerState {

    private float               _thrust = 2.0f;

    public PlayerJetpackState(Rigidbody2D body) : base(body){}

    public override void Init()
    {
        _body.gravityScale = 1.0f;
        _particles.transform.localPosition = new Vector3(-0.75f, -0.5f, -1.0f);
        _particles.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        _particles.Stop();
    }

    public override void Update() {
        if(Input.GetKeyDown(Define.Key))
            _particles.Play();
        else if(Input.GetKeyUp(Define.Key))
            _particles.Stop();
        else if(Input.GetKey(Define.Key))
            _body.AddForce(Vector2.up * _thrust);
    }
}

public class PlayerRocketState : PlayerState {

    private Vector2         _target;
    private float           _mass = 1.0f;
    private float           _slope = 10.0f;
    private float           _drag = -2.0f;

    public PlayerRocketState(Rigidbody2D body) : base(body){}

    public override void Init()
    {
        _body.gravityScale = 0.0f;
        _body.velocity = new Vector2(0.0f, 0.0f);
        _target = new Vector2(0.0f, 0.0f);
        _particles.transform.localPosition = new Vector3(-1.0f, 0.0f, -1.0f);
        _particles.transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        _particles.Play();
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

