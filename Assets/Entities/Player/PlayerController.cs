using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public float padding = 1f;
    public GameObject projectile;
    public Rigidbody2D rb2D;
    public float projectileSpeed;
    public float firingRate = 0.2f;
    public float health = 250f;
    public AudioClip fireSound; //AudioClip is the clip, whereas the source is just where it comes from.
    public AudioClip deathSound;

    public bool okToShoot = true;

    float xmin;
    float xmax;

	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z; // All of this stuff in Start is just doing the same stuff as the Formation Controller script.
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
        //GameObject playerProjectile = GameObject.FindWithTag("Player Projectile");
    }

    void Fire()
    {
        if (GameObject.FindGameObjectsWithTag("Player Projectile").Length == 0)     // I had this as <= 1 before.
        {
            Vector3 offset = new Vector3(0, 1, 0);                              // Spawns up the positive y axis by one so that it doesn't damage the Player by spawning on it!
            GameObject beam = Instantiate(projectile, transform.position + offset, Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);             // projectileSpeed shoots the laser up the screen (positive y axis).
            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
    }
	
	// Update is called once per frame
	void Update () {

        //if (GameObject.FindGameObjectsWithTag("Player Projectile").Length >= 1) { Destroy(GameObject.FindWithTag("Player Projectile")); } // May not be needed. More of a safety net.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //InvokeRepeating("Fire", 0.000001f, firingRate);
            //okToShoot bool = true;

            //if (GameObject.FindGameObjectsWithTag("Player Projectile").Length >= 1) { Destroy(GameObject.FindWithTag("Player Projectile")); } // May not be needed. More of a safety net.

            if (okToShoot == true)      // Currently pointless.
            {
                Fire();
            }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //CancelInvoke("Fire");
            //okToShoot = false;    // Maybe Invoke okToShoot in 1f
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //restrict the player to the gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missileCollisionDetected = collider.gameObject.GetComponent<Projectile>(); // Projectile is a script that is attached to the lasers tagged as Projectile.
        if (missileCollisionDetected)
        {
            health -= missileCollisionDetected.GetDamage();     // GetDamage() is in the Projectile script.
            missileCollisionDetected.Hit();                     // Hit() is in the Projectile script.
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {

        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadScene("Win Screen");        // Find a way to have this happen/invoke in like 3 seconds/3f.
    }

}
