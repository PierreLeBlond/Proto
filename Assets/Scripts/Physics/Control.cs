using UnityEngine;
using System.Collections;

public class Control {

    protected Rigidbody2D            _body;

    public Control(Rigidbody2D body)
    {
        _body = body;
    }

    public virtual void Init() {
    }

    public virtual void Update() {
    }
}


