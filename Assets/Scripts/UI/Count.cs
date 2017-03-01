using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Count : MonoBehaviour {

    public Text _text;

    private int _count = 0;

    public void Add() {
        _count++;
        Update();
    }

    public void Update() {
        _text.text = _count.ToString();
    }

    public void Reset() {
        _count = 0;
        Update();
    }
}

