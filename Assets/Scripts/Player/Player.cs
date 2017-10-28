using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Count                    count;

    public GameManager              gameManager;

    public Score                    score;

    public Rigidbody2D              body;

    private SpriteState             _spriteState;
    private SmokeState              _smokeState;

    private PlayerState[]           _states = new PlayerState[4];
    private PlayerState             _currentState;

    private int                     _currentStateId;
    private int                     _maxStateId;

    void Start() {

        _spriteState = GetComponent<SpriteState>();
        _smokeState = GetComponent<SmokeState>();

        for(int i = 0; i < _states.Length; ++i)
        {
            _states[i] = new PlayerState();
            _states[i].sprite = _spriteState;
            _states[i].smoke =  _smokeState;
            _states[i].spriteId = i;
        }

        _maxStateId = _states.Length - 1;

        _states[0].control = new Jump(body);
        _states[1].control = new Jetpack(body);
        _states[2].control = new Rocket(body);
        _states[3].control = new God(body, this);

        SetState(1);
    }

    void FixedUpdate () {
        if(Input.GetKeyDown("1"))
        {
            SetState(0);
        }
        else if(Input.GetKeyDown("2"))
        {
            SetState(1);
        }
        else if(Input.GetKeyDown("3"))
        {
            SetState(2);
        }
        else if(Input.GetKeyDown("4"))
        {
            SetState(3);
        }

        _currentState.Update();
    }

    void OnTriggerEnter2D(Collider2D intruder)
    {
        if(intruder.CompareTag("Collectable") && _currentStateId != 3)
            intruder.GetComponent<Collectable>().Activate(this);
    }

    void SetState(int state)
    {
        _currentStateId = state;

        _currentState = _states[_currentStateId];
        _currentState.Init();
    }

    public int getState() {
        return _currentStateId;
    }

    public int getMaxState() {
        return _maxStateId;
    }

    public void AddPoint() {
        count.Add();
    }

    public void LevelDown() {
        if(_currentStateId > 0)
        {
            SetState(_currentStateId - 1);
            score.Clean();
        }
        else
        {
            GameOver();
        }
    }

    public void LevelUp() {
        if(_currentStateId < _maxStateId)
        {
            SetState(_currentStateId + 1);
            score.Clean();
        }
    }

    public void SetLevel(int level) {
        SetState(level);
    }

    public void GameOver() {
        gameManager.GameOver();
    }

}

