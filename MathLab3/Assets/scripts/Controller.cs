using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        animator.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Target.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Target")
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Walk", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Target")
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Walk", true);
        }
    }
}
