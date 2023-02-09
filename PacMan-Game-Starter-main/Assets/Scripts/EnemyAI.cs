using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// FSM States for the enemy
public enum EnemyState { CHASE, MOVING, DEFAULT };
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public float chaseDistance = 20.0f;
    protected EnemyState state = EnemyState.DEFAULT;
    protected Vector3 destination = new Vector3(0, 0, 0);
    ParticleSystem bloodSplatterEffect;
    bool effectStarted = false;


    AudioSource myaudio;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        myaudio = GetComponent<AudioSource>();
        bloodSplatterEffect =
transform.GetComponent<ParticleSystem>();
    }
    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
    }
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.DEFAULT
        :
                destination = transform.position + RandomPosition();
                if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance
                )
                {
                    state = EnemyState.CHASE
                    ;
                }
                else
                {
                    state = EnemyState.MOVING
                    ;
                    agent.SetDestination(destination);
                }
                break;
            case EnemyState.MOVING
        :
                Debug.Log("Dest = " + destination);
                if (Vector3.Distance(transform.position, destination) < 0.05f)
                {
                    state = EnemyState.DEFAULT
                    ;
                }
                if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance
                )
                {
                    state = EnemyState.CHASE
                    ;
                }
                break;
            case EnemyState.CHASE
        :
                if (Vector3.Distance(transform.position, player.transform.position) > chaseDistance
                )
                {
                    state = EnemyState.DEFAULT
                    ;
                }
                agent.SetDestination
                (player.transform.position);
                break;
            default:
                break;
                

        }
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            // Disable all Renderers and Colliders
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer c in allRenderers) c.enabled = false;
            Collider[] allColliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allColliders) c.enabled = false;
            gameObject.GetComponent<ParticleSystemRenderer>().enabled =
true;
            StartBloodSplatter();
            StartCoroutine(PlayAndDestroy(myaudio.clip.length));
        }
    }
    private IEnumerator PlayAndDestroy(float waitTime)
    {
        myaudio.Play();
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
        StopBloodSplatter();

    }
    private void StartBloodSplatter()
    {
        if (effectStarted == false)
        {
            bloodSplatterEffect.Play();
            effectStarted = true;
        }
    }
    private void StopBloodSplatter()
    {
        effectStarted = false;
        bloodSplatterEffect.Stop(true,
        ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}