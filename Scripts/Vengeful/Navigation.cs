using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Spawned") && !animator.GetBool("Die"))  // Only move when fully spawned
        {
            agent.SetDestination(player.transform.position);  // update nav agents target position
        }   
    }
}
