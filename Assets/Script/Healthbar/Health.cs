using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float m_StartingHealth;
    public float m_CurrentHealth { get; private set; }
    private Animator m_Anim;
    private bool m_Dead;

    [Header("iFrames")]
    [SerializeField] private float m_IFramesDuration;
    [SerializeField] private int m_NumberOfFlashes;
    private SpriteRenderer m_SpriteRend;

    private void Awake()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Anim = GetComponent<Animator>();
        m_SpriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float Damage)
    {
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth - Damage,0,m_StartingHealth); //Fa si che l'operazione non esca da 0 a StartingHealth
        if(m_CurrentHealth > 0)
        {
            m_Anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
            //Invincibility Frames
        }
        else
        {
            if (!m_Dead)    //To not repeat the death more than once
            {
                m_Anim.SetTrigger("die");
                //Player
                if(GetComponent<PlayerMovement>() != null)
                    GetComponent<PlayerMovement>().enabled = false;

                //Enemy
                if (GetComponentInParent<EnemyPatrolling>() != null)
                    GetComponentInParent<EnemyPatrolling>().enabled = false;
                if(GetComponent<MeleeEnemy>() != null)  
                    GetComponent<MeleeEnemy>().enabled = false;
                m_Dead = true;
            }
        }
    }

    public void AddHealth(float Value)
    {
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth + Value, 0, m_StartingHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        //Invulnerability duration
        for (int i = 0; i < m_NumberOfFlashes; i++)
        {
            m_SpriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(m_IFramesDuration / (m_NumberOfFlashes * 2));
            m_SpriteRend.color = Color.white;
            yield return new WaitForSeconds(m_IFramesDuration / (m_NumberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
