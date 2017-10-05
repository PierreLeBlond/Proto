using UnityEngine;
using System;
using System.Collections;

public static class Define {
    public const string Key = "mouse 0";
}

public class PlayerState {

    public SpriteState               sprite;
    public int                       spriteId;

    public Control                   control;

    public SmokeState                smoke;

    public void Init()
    {
        sprite.SetState(spriteId);
        smoke.SetState(spriteId);
        control.Init();
    }

    public void Update()
    {
        control.Update();
        smoke.Update();
    }
}



