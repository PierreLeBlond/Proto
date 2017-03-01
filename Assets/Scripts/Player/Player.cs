using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Count count;

    public GameManager gameManager;

    public Score score;

    public Rigidbody2D body;

    public ParticleSystem particles;

    private PlayerState[] _states = new PlayerState[3];
    private PlayerState _currentState;

    private int _currentStateId;

    void Start() {

        _states[0] = new PlayerJumpState(body);
        _states[0].SetParticleSystem(particles);
        _states[1] = new PlayerJetpackState(body);
        _states[1].SetParticleSystem(particles);
        _states[2] = new PlayerRocketState(body);
        _states[2].SetParticleSystem(particles);

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

        _currentState.Update();
    }

    void OnTriggerEnter2D(Collider2D intruder)
    {
        if(intruder.CompareTag("Collectable"))
            intruder.GetComponent<Collectable>().Activate(this);
    }

    void SetState(int state)
    {
        _currentStateId = state;

        _currentState = _states[_currentStateId];
        _currentState.Init();

        GetComponent<SpriteState>().SetState(_currentStateId);
    }

    public int getState() {
        return _currentStateId;
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
        if(_currentStateId < 2)
        {
            SetState(_currentStateId + 1);
            score.Clean();
        }
    }

    public void GameOver() {
        gameManager.GameOver();
    }

}

