using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMove : MonoBehaviour
{
    //障礙物的移動速度
    public float _speed;
    //障礙物的移動最大值;
    public float _range = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //障礙物來回移動(0~最大值)
        transform.position = new Vector3(Mathf.PingPong(Time.time * _speed, _range), transform.position.y, transform.position.z);
    }
}
