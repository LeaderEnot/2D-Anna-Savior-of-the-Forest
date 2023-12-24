using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovements : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Animator monsterAnimator; 
    bool isFacingRight = true; 

    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        monsterAnimator = GetComponent<Animator>(); 
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            monsterAnimator.SetBool("isFighting", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }
    }

    void FlipEnemyFacing()
    {
        isFacingRight = !isFacingRight; 
        transform.localScale = new Vector2((isFacingRight ? 1 : -1), 1f);
        monsterAnimator.SetBool("isFighting", false); 
    }
}
