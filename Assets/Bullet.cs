using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 targetPosition;
    private float bulletSpeed;
    public int damage = 100; // Kerusakan yang dihasilkan proyektil

    public void SetTarget(Vector3 target, float speed)
    {
        targetPosition = target;
        bulletSpeed = speed;
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);

        // Hancurkan proyektil jika sudah mencapai target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Deteksi collision dengan musuh
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject); // Hancurkan proyektil setelah menimbulkan damage
        }
    }
}
