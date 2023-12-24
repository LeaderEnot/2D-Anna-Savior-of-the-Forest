using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public bool AttackInputReceived;
    public bool AllowedToAttack;
    public bool PlayerIsAttacking;
    public Animator anim;
   

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckIfAttackKeyPressed();
        DoAttacks();

        
    }

    void CheckIfAttackKeyPressed()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (AllowedToAttack == true)
            {
                AttackInputReceived = true;
            }
        }
    }

    void DoAttacks()
    {
        if (AttackInputReceived == true)
        {
            if (PlayerIsAttacking == false)
            {
                anim.SetBool("isAttacking", true);

                

                PlayerIsAttacking = true;
                AttackInputReceived = false;
            }
        }
    }

   

    
    void FirstAttackDone()
    {
        PlayerIsAttacking = false;
        anim.SetBool("isAttacking", false);
    }
}
