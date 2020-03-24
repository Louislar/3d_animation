using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Animation _anim;
    private bool _isZaxis = false, _isXaxis = false, _isCrash = false;
    private float start, end;
    private float _starttime;
    private float lerpvalue;
    public float _speed;
    //public Catch_player CatchPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            start = transform.position.z;
            end = start + 1;
            ZaxisMove();
        }
        else if (Input.GetKeyDown("s"))
        {
            start = transform.position.z;
            end = start - 1;
            ZaxisMove();
        }
        else if (Input.GetKeyDown("d"))
        {
            start = transform.position.x;
            end = start + 1;
            XaxisMove();
        }
        else if (Input.GetKeyDown("a"))
        {
            start = transform.position.x;
            end = start - 1;
            XaxisMove();
        }


        if (_isZaxis && !_isCrash)
        {
            lerpvalue = Mathf.Lerp(start, end, (Time.time - _starttime) * _speed);
            transform.position = new Vector3(transform.position.x, transform.position.y, lerpvalue);
            if (transform.position.z == end) _isZaxis = false;
        }
        if (_isXaxis && !_isCrash)
        {
            lerpvalue = Mathf.Lerp(start, end, (Time.time - _starttime) * _speed);
            transform.position = new Vector3(lerpvalue, transform.position.y, transform.position.z);
            if (transform.position.x == end) _isXaxis = false;
        }

    }

    public void ZaxisMove()
    {
        Catch_player._isCatch = false;
        _anim.Play("New Animation");
        _isZaxis = true;
        _isXaxis = false;
        _starttime = Time.time;
        _isCrash = false;
    }

    public void XaxisMove()
    {
        Catch_player._isCatch = false;
        _anim.Play("New Animation");
        _isZaxis = false;
        _isXaxis = true;
        _starttime = Time.time;
        _isCrash = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Obstacle")
        {
            Debug.Log("撞到障礙物了!!!");
        }
    }
}
