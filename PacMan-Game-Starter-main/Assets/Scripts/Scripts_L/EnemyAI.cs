using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// FSM States for the enemy
public enum EnemyState { ATTACK, CHASE, MOVING, DEFAULT };
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public float chaseDistance = 20.0f;
    protected EnemyState state = EnemyState.DEFAULT;
    protected Vector3 destination = Vector3.zero;
    Animator animator;
    AudioSource myaudio;
    public GameObject junkCube;
    public float junkTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        myaudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        junkTimer += Time.deltaTime;
        if(junkTimer >= 20)
        {
            junkTimer = 0;
            Instantiate(junkCube, transform.position, Quaternion.identity);
        }

        HandleEnemyAIStates();
    }
    void HandleEnemyAIStates()
    {
        //Debug.Log("Enemy State is " + state);
        switch (state)
        {
            case EnemyState.DEFAULT:
                agent.SetDestination(player.transform.position);
                animator.SetBool("isRunning", true);
                agent.speed = 3.0f;
                break;
            default:
                break;
        }
    }
}