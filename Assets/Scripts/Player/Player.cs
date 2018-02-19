using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Count                    count;

    public PlayerState[]           states;

    public GameManager              gameManager;
    public TimeManager              timeManager;

    public ObjectManager            objectManager;
    public Rigidbody                body;
    public BoxCollider              mouseCollider;

    public Animation                levelUpEffect;
    public Animation                levelDownEffect;

    //private SpriteState             _spriteState;
    //private SmokeState              _smokeState;

    private PlayerState             _currentState;

    private int                     _currentStateId;
    private int                     _maxStateId;

    void Start() {

        /*_spriteState = GetComponent<SpriteState>();
        _smokeState = GetComponent<SmokeState>();*/

        /*for(int i = 0; i < states.Length; ++i)
        {
            states[i] = new PlayerState();
            states[i].sprite = _spriteState;
            states[i].smoke =  _smokeState;
            states[i].spriteId = i;
        }*/

        _maxStateId = states.Length - 1;

        foreach (var state in states) {
            state.gameObject.SetActive(false);
        }

        /*states[0].control = new Jump(body, mouseCollider);
        states[1].control = new Jetpack(body, mouseCollider);
        states[2].control = new Rocket(body, mouseCollider);
        states[3].control = new God(body, mouseCollider, this);*/

        SetState(0);
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

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Collectable") && _currentStateId != 3) {
            collider.gameObject.GetComponent<Collectable>().Activate(this);
        }
    }

    void SetState(int state)
    {
        if(_currentState) {
            _currentState.gameObject.SetActive(false);
        }
        _currentStateId = state;

        _currentState = states[_currentStateId];
        _currentState.gameObject.SetActive(true);
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
            levelDownEffect.Play();
            SetState(_currentStateId - 1);
            timeManager.SlowTime(.05f, 2f);
            //objectManager.Stop();
            //objectManager.Clear();
            //objectManager.Launch();
        }
        else
        {
            GameOver();
        }
    }

    public void LevelUp() {
        if(_currentStateId < _maxStateId)
        {
            levelUpEffect.Play();
            SetState(_currentStateId + 1);
            timeManager.SlowTime(.05f, 2f);
            //objectManager.Stop();
            //objectManager.Clear();
            //objectManager.Launch();
        }
    }

    public void SetLevel(int level) {
        SetState(level);
    }

    public void GameOver() {
        gameManager.GameOver();
    }

}
