using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtDamage : MonoBehaviour
{

    [SerializeField] int health;
    [SerializeField] float enemyDeathTimer = 0.5f;
    [SerializeField] MonoBehaviour movementScript;

    Animator anim;
    GameManager gameManager;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DamageEnemy(int damageToDeal)
    {
        health -= damageToDeal;
        anim.SetTrigger("isHit");

        AkSoundEngine.PostEvent("ext_damage", gameObject);

        if (health <= 0)
        {
            anim.SetTrigger("isDead");
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;

            movementScript.enabled = false;

            AkSoundEngine.PostEvent("ext_death", gameObject);

            Invoke("KillEnemy", enemyDeathTimer);
        }
    }

    void KillEnemy()
    {
        gameManager.EnemyDead();
        Destroy(gameObject);
    }
}