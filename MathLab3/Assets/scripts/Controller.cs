using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    private Animator animator;
    float characterSpeedSlider;


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

    void OnGUI()
    {
        float additionalSpeed = 1.0f;

        //Create a Label in Game view for the Slider
        GUI.Label(new Rect(0, 25, 40, 60), "Knight Speed");

        //Create a horizontal Slider to control the speed of the Animator. Drag the slider to 1 for normal speed.

        characterSpeedSlider = GUI.HorizontalSlider(new Rect(45, 25, 200, 60), characterSpeedSlider, 0.0F, 5.0F);
      
        //Make the speed of the Animator match the Slider value
        animator.speed = characterSpeedSlider;
        agent.speed = animator.speed * 2f;
        
        

    }
}
