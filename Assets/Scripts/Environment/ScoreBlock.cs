using UnityEngine;
using System.Collections;

public class ScoreBlock : MonoBehaviour {

    public Transform linePrefab;

    public Note notePrefab;
    private Note _note;

    public Bonus bonusPrefab;
    private Bonus _bonus;

    private Transform[] _lines = new Transform[5];
    private Transform[] _verticalLines = new Transform[2];

    void Start() {

        for(int i = 0; i < _lines.Length; ++i)
        {
            _lines[i] = Instantiate (linePrefab) as Transform;
            _lines[i].parent = transform;
            _lines[i].localPosition = new Vector3(0.0f, i - 2, 0.0f);
            _lines[i].localScale = new Vector3(4.0f, 1.0f, 1.0f);
        }

        for(int i = 0; i < _verticalLines.Length; ++i)
        {
            _verticalLines[i] = Instantiate (linePrefab) as Transform;
            _verticalLines[i].parent = transform;
            _verticalLines[i].localPosition = new Vector3(4.0f*i - 2.0f, 0.0f, 0.0f);
            _verticalLines[i].localScale = new Vector3(4.0f, 1.0f, 1.0f);
            _verticalLines[i].localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }

        _note = Instantiate (notePrefab) as Note;
        _note.transform.parent = transform;

        _bonus = Instantiate (bonusPrefab) as Bonus;
        _bonus.transform.parent = transform;

        Clean();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(-3.0f, 0.0f, 0.0f);
    }

    public void SpamBonus(int state) {
        Clean();
        _bonus.transform.localPosition = new Vector3(0.0f, Random.Range(-6, 6)/2.0f, 0.0f);
        _bonus.GetComponent<SpriteState>().SetState(state);
        _bonus.gameObject.SetActive(true);
    }

    public void SpamNote() {
        Clean();
        _note.transform.localPosition = new Vector3(0.0f, Random.Range(-6, 6)/2.0f, 0.0f);
        int state = Random.Range(0, 2);
        _note.GetComponent<SpriteState>().SetState(state);
        _note.SetRightness(state == 0);
        _note.gameObject.SetActive(true);
    }

    public void Clean() {
        _note.gameObject.SetActive(false);
        _bonus.gameObject.SetActive(false);
    }
}


