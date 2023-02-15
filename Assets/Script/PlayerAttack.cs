using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float m_AttackCooldown; //Attack speed of the player
    private Animator m_Anim;
    private PlayerMovement m_PlayerMovement;
    private float m_CooldownTimer = Mathf.Infinity; //Setting a timer so you cant spam attack

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
        m_PlayerMovement = GetComponent<PlayerMovement>();   
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z) && m_CooldownTimer > m_AttackCooldown && m_PlayerMovement.canAttack())  //When can I attack
            Attack();
        m_CooldownTimer += Time.deltaTime; //Setting the cooldown timer every frame
    }

    private void Attack()
    {
        m_Anim.SetTrigger("attack");
        m_CooldownTimer = 0; //Setting the timer to zero so we cant attack instantly
    }
}
