using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Count : MonoBehaviour {

    public Player                   player;
    public Text                     text;
    public Slider                   slider;
    //public Transform               mask;

    private int                    _count = 0;
    private int                    _maxCount = 10;

    public void Add() {
        _count++;
        if(_count > _maxCount) {
            player.LevelUp();
            _count = 0;
        }
        UpdateSlider();
    }

    public void UpdateSlider() {
        slider.value = _count/10.0f;
        //text.text = _count.ToString();
        //mask.localPosition = new Vector2((float)_count/5.0f, 0.0f);
    }

    public void Reset() {
        _count = 0;
        //mask.localPosition = new Vector2(0.0f, 0.0f);
        UpdateSlider();
    }
}
