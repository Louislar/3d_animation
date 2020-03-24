using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_player : MonoBehaviour
{
    public static bool _isCatch = false;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (_isCatch)
        {
            Player.transform.position = new Vector3(transform.position.x, Player.transform.position.y,
           transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _isCatch = true;
            Player = collision.gameObject;
        }
    }
}
