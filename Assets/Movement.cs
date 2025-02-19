using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent ai;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        ai.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        ai.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
