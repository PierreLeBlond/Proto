using UnityEngine;
using System.Collections;

public class SpriteState : MonoBehaviour {

    public SpriteRenderer spriteRenderer;

    public Sprite[] _sprites;

    private Sprite _currentSprite;

    private int _state;

    public void SetState(int state)
    {
        _state = state;
        spriteRenderer.sprite = _sprites[_state];
    }
}

