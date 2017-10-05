using UnityEngine;
using System.Collections;

public class SmokeState : MonoBehaviour {

    public ParticleSystem  _smoke;

    private int             _state;

    public void SetState(int state)
    {
        switch(state)
        {
          case 0 :
            _smoke.gameObject.SetActive(true);
            _smoke.transform.localPosition = new Vector3(-0.5f, -0.4f, 0.0f);
            break;
          case 1 :
            _smoke.gameObject.SetActive(true);
            _smoke.transform.localPosition = new Vector3(-0.5f, -0.4f, 0.0f);
            _smoke.Play();
            break;
          case 2 :
            _smoke.gameObject.SetActive(true);
            _smoke.Play();
            break;
          case 3 :
            _smoke.gameObject.SetActive(false);
            break;
          default:
            break;
        }

        _state = state;
    }

    public void Update()
    {
        if(Input.GetKeyDown(Define.Key))
        {
            switch(_state)
            {
              case 0 :
                _smoke.Emit(5);
                break;
              case 1 :
                _smoke.Play();
                break;
              default:
                break;
            }
        }

        if(Input.GetKeyDown(Define.Key) && _state == 1)
            _smoke.Stop();
    }
}

