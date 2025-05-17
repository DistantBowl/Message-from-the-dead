using UnityEngine;

public class Damage : MonoBehaviour
{
    private PlayerValues playerValues;
    private Animator animator;
    public AudioClip damage;


    private void Start()
    {
        playerValues = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(playerValues.transform.position, gameObject.transform.position);

        if (distance <= 0.85 && !animator.GetBool("Die") && animator.GetBool("Spawned")) 
        {
            playerValues.health--;
            playerValues.gameObject.GetComponent<AudioSource>().PlayOneShot(damage);
            animator.SetBool("Die", true);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animator.GetBool("Die"))
        {
            Destroy(gameObject);
        }
    }
}
