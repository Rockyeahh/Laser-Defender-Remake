using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float health = 150f;
    public float startingHealth;
    public GameObject projectile;
    public float projectileSpeed = 10;
    public Rigidbody2D rb2D;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 150;
    public AudioClip fireSound;
    public AudioClip deathSound;
    public Vector3 startPosition;

    private ScoreKeeper scoreKeeper;


    void Awake()
    {
        startPosition = transform.position;
        startingHealth = health;
    }

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability)     // Stops the enemy from shooting in a predicatable way.
        {
            Fire();
        }

    }

    void Fire()
    {
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;    // Merely spawns the projectile.
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);       // It's -projectileSpeed because it's moving down the screen in the -y axis.
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missileCollisionDetected = collider.gameObject.GetComponent<Projectile>();// Projectile is a script that is attached to the lasers tagged as Projectile.
        if (missileCollisionDetected)
        {
            health -= missileCollisionDetected.GetDamage();  // GetDamage() is in the Projectile script.
            missileCollisionDetected.Hit();                  // Hit() is in the Projectile script.
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position); // The sound plays at the transform.position of the gameobject that this script on.
        //Destroy(gameObject);             // CHANGE to disable gameObject.
        gameObject.SetActive(false);
        //transform.position = startPosition; // Reset to starting position   // The tranform that needs to be rest is the enemy formation not the children.
        health = startingHealth; // Reset enemy health
        // Reset animation state? anim.trigger("Entry")???
        scoreKeeper.Score(scoreValue);  // Updates score.
    }
}
