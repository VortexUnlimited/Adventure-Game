using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Transform player;

    static GameObject startPos;

    // Start is called before the first frame update
    void Start()
    {
        if(startPos == null)
        {
            startPos = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        foreach(Transform trans in FindObjectsOfType<Transform>())
        {
            if(trans.CompareTag("Player"))
            {
                player = trans;
            }
        }

        if (player)
        {
            player.position = transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
