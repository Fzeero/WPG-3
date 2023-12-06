using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float detectionRange = 10.0f;
    public float stoppingDistance = 2.0f;
    public int damageAmount = 10; // Jumlah damage yang akan diberikan ke karakter saat bersentuhan dengan musuh
    private Transform player;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            if (distanceToPlayer > stoppingDistance)
            {
                Vector3 moveDirection = (player.position - transform.position).normalized;
                transform.Translate(moveDirection * speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Jika terjadi collision dengan karakter, berikan damage ke karakter
            CharacterHealth characterHealth = collision.gameObject.GetComponent<CharacterHealth>();
            if (characterHealth != null)
            {
                characterHealth.TakeDamage(damageAmount);
            }
        }
    }
}
