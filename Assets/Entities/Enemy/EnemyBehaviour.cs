using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float health = 150f;
    public GameObject projectile;
    public float projectileSpeed = 10;
    public Rigidbody2D rb2D;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 150;
    public AudioClip fireSound;
    public AudioClip deathSound;

    private ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability)
        {
            Fire();
        }

    }

    void Fire()
    {
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
                AudioSource.PlayClipAtPoint(deathSound, transform.position); //The sound happens at the transform.position of the gameobject that this script on.
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);
    }
}
