using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab proyektil (bullet)
    public Transform firePoint; // Titik pelemparan proyektil
    public float bulletSpeed = 10.0f; // Kecepatan proyektil
    public LayerMask enemyLayer; // Lapisan musuh
    public int damage = 1; // Kerusakan yang dihasilkan proyektil
    public float fireRate = 0.2f; // Tingkat tembakan per detik
    private float nextFireTime = 0f; // Waktu berikutnya pemain dapat menembak
    private Transform target; // Musuh yang menjadi target proyektil

    private void Update()
    {
        FindNearestEnemy();
        if (target != null && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1.0f / fireRate;
            Shoot();
        }
    }

    private void FindNearestEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100f, enemyLayer);
        Transform nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Collider col in colliders)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, col.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = col.transform;
            }
        }

        target = nearestEnemy;
    }

    private void Shoot()
    {
        if (target != null)
        {
            RaycastHit hit;
            Vector3 targetPosition = target.position;

            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, Mathf.Infinity, enemyLayer))
            {
                targetPosition = hit.point; // Atur posisi target jika terdapat tumbukan dengan musuh
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetTarget(targetPosition, bulletSpeed);
            }
        }
    }
}
