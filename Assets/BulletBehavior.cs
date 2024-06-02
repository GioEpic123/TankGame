using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float BULLET_TIME = 3f;
    public int BOUNCE_MAX = 3;

    public float damage;
    private Rigidbody rb;

    public GameObject bulletSource;

    private int bounces = 0;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(BulletTimeOut());
    }

    void FixedUpdate()
    {
        // Keeps all bullets at the same height regardless of non-damaging collisions (makes for fun bullet physics)
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
    }

    IEnumerator BulletTimeOut()
    {
        yield return new WaitForSeconds(BULLET_TIME);
        KillBullet();
    }

    private void OnTriggerEnter(Collider other)
    {

        //Prevent consuming bullet on exit (& non-ricochet friendly fire)
        if (bulletSource && other.CompareTag(bulletSource.tag) && bounces == 0)
        {
            return;
        }

        var damagable = other.GetComponent<iDamagable<float>>();
        if (damagable != null)
        {
            // If Damagable & not from source
            Debug.Log("Bullet Hit " + other.gameObject.name);
            damagable.takeDamage(damage);
            KillBullet();
        }
        else
        {
            // If Not
            if (other.CompareTag("Ground"))
            {
                // Bounce if Ground or Wall
                if (bounces < BOUNCE_MAX)
                {
                    Debug.Log("Bounce! " + other.gameObject);

                    // Raycast to determine surface normal
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, rb.velocity.normalized, out hit))
                    {
                        Vector3 surfaceNormal = hit.normal;
                        Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, surfaceNormal);
                        rb.velocity = reflectedVelocity;
                        bounces++;
                    }
                    else
                    {
                        // If raycast fails, destroy bullet
                        Debug.Log("Raycast failed!");
                        KillBullet();
                    }
                }
                else
                {
                    Debug.Log("Bounced out! " + other.gameObject);
                    KillBullet();
                }
            }
            else
            {
                Debug.Log("Hit non-dmg, non Wall object:" + other.gameObject);
            }
        }
    }

    void KillBullet()
    {
        Destroy(gameObject);
    }
}
