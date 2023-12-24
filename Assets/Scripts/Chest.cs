using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Chest : MonoBehaviour
{
    public Animator chestAnimator;

    private bool isOpen = false;
    private bool playerNearby = false;

    private void Start()
    {
        chestAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerNearby && !isOpen)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                isOpen = true;
                chestAnimator.SetBool("isOpen", isOpen); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
