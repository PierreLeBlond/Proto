using UnityEngine;
using System.Collections;

public class Note : Collectable {

    private bool _isRight;

    public void SetRightness(bool isRight) {
        _isRight = isRight;
    }

    public override void Activate(Player player)
    {
        Debug.Log(_isRight);
        if(!_isRight)
            player.LevelDown();
        else
            player.AddPoint();
        gameObject.SetActive(false);
    }
}


