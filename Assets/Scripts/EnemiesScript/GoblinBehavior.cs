using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


internal enum GoblinState
{
    Goblin_idle, Goblin_attack, Goblin_death
}
public class GoblinBehavior : MonoBehaviour
{
    TowersLastDefenders lastDefenders;
    GoblinHealthBar healthBar;
    GoblinAttacking goblinAttack;
    Animator animator;
    private bool isIdle = true;
    private bool isAttacking;
    private bool isDying;
    GoblinState currentState = GoblinState.Goblin_idle;
    void Awake() 
    {
        lastDefenders = GetComponentInParent<TowersLastDefenders>();
        goblinAttack = GetComponent<GoblinAttacking>();
        healthBar = GetComponent<GoblinHealthBar>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentState = GoblinState.Goblin_idle;
    }
    void Update()
    {
        if(healthBar.CanBeDestroyed)
        {
            isIdle = false;
            isAttacking = false;
            isDying = true;
        }
        else if(goblinAttack.IsAttacking)
        {
            isIdle = false;
            isAttacking = true;
            isDying = false;        
        }
    }
    void ChangeAnimationState(GoblinState newState)
    {
        if(currentState == newState)
            return;
        
        animator.Play(newState.ToString());
        
        if(newState == GoblinState.Goblin_death)
            StartCoroutine(GoblinDying());

        currentState = newState;
    }
    void FixedUpdate() 
    {
        if(isIdle)
        {
            ChangeAnimationState(GoblinState.Goblin_idle);
        }
        else if(isAttacking)
        {
            ChangeAnimationState(GoblinState.Goblin_attack);
        }
        else if(isDying)
        {
            ChangeAnimationState(GoblinState.Goblin_death);
        }    
    }
    IEnumerator GoblinDying()
    {
        yield return new WaitForSeconds(5f);
        lastDefenders.GoblinDeath(this.gameObject);
        yield break;
    }
}
