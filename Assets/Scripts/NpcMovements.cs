using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class NpcMovements : MonoBehaviour
{
    public float runSpeed = 5.0f; 
    public float runDuration = 3.0f; 
    public float idleDuration = 2.0f; 
    private Animator animator;
    private bool isRunning = false;
    private bool isFacingLeft = true; 

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(RunAndIdle());
    }

    private IEnumerator RunAndIdle()
    {
       
        isRunning = true;
        animator.SetBool("isRunning", true);
        yield return new WaitForSeconds(runDuration);
        isRunning = false;
        animator.SetBool("isRunning", false);

       
    }

    private void Update()
    {
        if (isRunning)
        {
            
            Vector3 newPosition = transform.position + (isFacingLeft ? Vector3.left : Vector3.right) * runSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}
