using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    public Item itemPrefab;
    public Player player;

    private Item[] _items = new Item[6];

    public void Start() {
        for(int i = 0; i < _items.Length;++i)
        {
            _items[i] = Instantiate (itemPrefab) as Item;
        }
    }

    public void SpamItems() {
        for(int i = 0; i < _items.Length;++i)
        {
            Transform itemTransform = _items[i].transform;
            itemTransform.SetParent(transform, false);
            Vector3 localPosition = itemTransform.localPosition;
            localPosition.x = i*4.0f + 9.0f;
            itemTransform.localPosition = localPosition;
            _items[i].Spam();
        }
    }

    public void FixedUpdate() {
        for(int i = 0; i < _items.Length;++i)
            if(_items[i].transform.localPosition.x < -12.0f)
            {
                Vector3 localPosition = _items[i].transform.localPosition;
                localPosition.x = 12.0f;
                _items[i].transform.localPosition = localPosition;
                _items[i].Spam();
            }
    }

    public void Clean() {
        for(int i = 0; i < _items.Length;++i)
        {
            _items[i].Clean();
        }
    }
}

