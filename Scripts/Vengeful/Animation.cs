using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Animation : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animator.GetBool("Spawned")) 
        {
            animator.SetBool("Spawned", true);
        }

        animator.SetFloat("Angle Right", Vector2.Angle(Vector2.right, agent.velocity));
        animator.SetFloat("Angle Left", Vector2.Angle(Vector2.left, agent.velocity));
        animator.SetFloat("Angle Back", Vector2.Angle(Vector2.down, agent.velocity));
        animator.SetFloat("Angle Forward", Vector2.Angle(Vector2.up, agent.velocity));
    }
}
