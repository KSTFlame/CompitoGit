using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float m_AttackCooldown;
    [SerializeField] private int m_Damage;
    [SerializeField] private BoxCollider2D m_BoxCollider;

    [Header ("Collider Parameters")]
    [SerializeField] private LayerMask m_PlayerLayer;
    [SerializeField] private float m_Range;

    [Header("Player Layer")]
    [SerializeField] private float m_ColliderDistance;
    private float m_CooldownTimer = Mathf.Infinity;

    //References
    private Animator m_Anim;
    private Health m_PlayerHealth;

    private EnemyPatrolling m_EnemyPatrol;

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();   
        m_EnemyPatrol = GetComponentInParent<EnemyPatrolling>();
    }

    private void Update()
    {
        m_CooldownTimer += Time.deltaTime;

        if(PlayerInsight())
            if(m_CooldownTimer >= m_AttackCooldown)
            {
                m_CooldownTimer = 0;
                m_Anim.SetTrigger("meleeAttack");
            }
        if (m_EnemyPatrol != null)
            m_EnemyPatrol.enabled = !PlayerInsight();
    }

    private bool PlayerInsight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(m_BoxCollider.bounds.center + transform.right * m_Range * transform.localScale.x * m_ColliderDistance, 
            new Vector3(m_BoxCollider.bounds.size.x * m_Range, m_BoxCollider.bounds.size.y, m_BoxCollider.bounds.size.z), 
            0, Vector2.left, 0, m_PlayerLayer);

        if(hit.collider != null)
            m_PlayerHealth = hit.transform.GetComponent<Health>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(m_BoxCollider.bounds.center + transform.right * m_Range * transform.localScale.x * m_ColliderDistance, 
            new Vector3(m_BoxCollider.bounds.size.x * m_Range, m_BoxCollider.bounds.size.y, m_BoxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        //If Player still in range damage him
        if (PlayerInsight())
            m_PlayerHealth.TakeDamage(m_Damage);
    }
}
