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
    public AudioClip fireSound; //AudioClip is different to audio source somehow. Also fireSound is the name you create for it in the code and is something 
    //i never think to do as I am used to worrying where to find the correct code online or in previous scripts as I don't know enough to write code myself.
    public AudioClip deathSound;

    float xmin;
    float xmax;

	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z; // All of this stuffin Start is just doing the same stuff as the Formation Controller script.
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    void Fire()
    {
        Vector3 offset = new Vector3(0, 1, 0);                              // Spawns up the positive y axis by one so that it doesn't damage the Player by spawning on it!
        GameObject beam = Instantiate(projectile, transform.position + offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);             // projectileSpeed shoots the laser up the screen (positive y axis).
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
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
        man.LoadLevel("Win Screen");
    }

}
