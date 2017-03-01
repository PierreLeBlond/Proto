using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public ScoreBlock scoreBlockPrefab;
    public Player player;

    private ScoreBlock[] _blocks = new ScoreBlock[6];

    void Start() {
        for(int i = 0; i < _blocks.Length;++i)
        {
            _blocks[i] = Instantiate (scoreBlockPrefab) as ScoreBlock;
            _blocks[i].transform.parent = transform;
            _blocks[i].transform.localPosition = new Vector3(i*4.0f - 9.0f, 0.0f, 0.0f);
        }
    }

    void FixedUpdate() {
        for(int i = 0; i < _blocks.Length;++i)
            if(_blocks[i].transform.position.x < -12.0f)
            {
                _blocks[i].transform.localPosition = new Vector3(12.0f, 0.0f, 0.0f);
                if(player.getState() < 2 && Random.Range(0, 10) == 0)
                    _blocks[i].SpamBonus(player.getState());
                else
                    _blocks[i].SpamNote();
            }
    }

    public void Clean() {
        for(int i = 0; i < _blocks.Length;++i)
        {
            _blocks[i].Clean();
        }
    }
}

