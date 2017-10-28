using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Count : MonoBehaviour {

    public Text                    text;
    //public Transform               mask;

    private int                    _count = 0;

    public void Add() {
        _count++;
        Update();
    }

    public void Update() {
        text.text = _count.ToString();
        //mask.localPosition = new Vector2((float)_count/5.0f, 0.0f);
    }

    public void Reset() {
        _count = 0;
        //mask.localPosition = new Vector2(0.0f, 0.0f);
        Update();
    }
}

