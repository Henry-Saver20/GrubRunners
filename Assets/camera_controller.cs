using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos  = player.transform.position;
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
