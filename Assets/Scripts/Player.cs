using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float range;
    public int damage;
    public int health;
    public int maxHealth;
    public Transform explosion;
    public GameObject explVFX;
    public Image healthBar;

    public SkillManager skillManager; 
    private float moveInputX;
    private float moveInputY;
 //   private float startTimeBtwDashes;

    private Vector2 movementDirection;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private GameManager gm;

    private bool pcMovement;
    private bool otherMovement;
    public bool isDamageable;
    //private bool canDash;

    private int direction;


    //legate de inventar
    [SerializeField] private List<Weapon> inventory;
    private float nextShot = 0.0f;

    private Weapon currentWeapon;

    [Header("Dashing")]
    public float timeBtwDashes;
    public float dashSpeed;
    public float dashTime;
    private bool canDash = true;
    public GameObject dashVFX;



    void Start()
    {
#if UNITY_EDITOR
        Debug.Log("Editor");
        pcMovement = true;
#elif UNITY_STANDALONE_WIN
                Debug.Log("Windows");
                pcMovement = true;
        
#endif

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        currentWeapon = inventory[0];
        isDamageable = true;
        health = maxHealth;
        //canDash = false;
        // startTimeBtwDashes = timeBtwDashes;
    }

    private void Update()
    {
       // Color c = sr.material.color;
       // c.a = 0.5f;
       // sr.material.color = c;
        /*  c.a = 1f;
          sr.material.color = c;*/

        //Shoot();
        ChangeWeapon();
        Explosion();
        Invulnerability();
      //  Dash();
        OnYandereSimCodeLMAO();
      
        dashVFX.GetComponent<ParticleSystem>().textureSheetAnimation.SetSprite(0, sr.sprite);
    }

    private void FixedUpdate()
    {
        if (pcMovement)

        {
            moveInputX = Input.GetAxisRaw("Horizontal");
            moveInputY = Input.GetAxisRaw("Vertical");
            movementDirection = new Vector2(moveInputX, moveInputY);
            movementDirection.Normalize();
            rb.velocity = movementDirection * speed;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashingAbility();
        }
        // Debug.Log(rb.velocity.magnitude);

        /* if (Input.GetKey(KeyCode.D))
         { rb.velocity += Vector2.right * speed * Time.deltaTime; }
          if (Input.GetKey(KeyCode.A)) {

             rb.velocity += -Vector2.right * speed * Time.deltaTime; 
         }
          if (Input.GetKey(KeyCode.W))
         {

             rb.velocity += Vector2.up * speed * Time.deltaTime;
         }
          if (Input.GetKey(KeyCode.S))
         {

             rb.velocity += Vector2.down * speed * Time.deltaTime;
         }*/

        //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speed, speed), Mathf.Clamp(rb.velocity.y, -speed, speed));
    }

    private void DashingAbility()
    {
        if(canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        float initialSpeed = this.speed;
        this.speed = dashSpeed;
        Instantiate(dashVFX, this.transform.position, transform.rotation);
        yield return new WaitForSeconds(0.05f);
        Instantiate(dashVFX, this.transform.position, transform.rotation);
        yield return new WaitForSeconds(0.05f);
        Instantiate(dashVFX, this.transform.position, transform.rotation);
        yield return new WaitForSeconds(dashTime);
        this.speed = initialSpeed;
        yield return new WaitForSeconds(timeBtwDashes);
        canDash = true;

    }

    public void TakeDamage(int damage)
    {
        if(isDamageable == true)
        this.health -= damage;
        
    }

    private void MoveOnPcAndEditor()
    {

    }

    private void ChangeWeapon()
    {
        foreach (char c in Input.inputString)
        {
            int index = c - '0' - 1;
            if (index >= 0 && index < inventory.Count)
            {
                currentWeapon = inventory[index];
            }
        }
        Shooting daniel = GetComponent<Shooting>();
        daniel.daniel = currentWeapon;
        GetComponent<SpriteRenderer>().sprite = currentWeapon.sprite;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextShot)
        {
            nextShot += currentWeapon.cooldown;
            currentWeapon.Shoot(transform);
        }
    }


    private void Invulnerability()
    {
        if(Input.GetKeyDown(KeyCode.X) && skillManager.skills[1].isReady)
        {
            StartCoroutine(InvulnerabilitySkill());
            skillManager.skills[1].isReady = false;
            skillManager.skills[1].currentCoolDown = 0;
        }
    }

    private IEnumerator InvulnerabilitySkill()
    {
        isDamageable = false;
        Color auxiliary = sr.material.color;
        sr.material.color = Color.yellow;
        yield return new WaitForSeconds(skillManager.skills[1].GetComponent<InvulnerabilitySkill>().duration);
        sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, 0.5f);
        yield return new WaitForSeconds(0.2f);
        sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, 1f);
        yield return new WaitForSeconds(0.2f);
        sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, 0.5f);
        yield return new WaitForSeconds(0.2f);
        sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, 1f);
        yield return new WaitForSeconds(0.2f);
        sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, 0.5f);
        yield return new WaitForSeconds(0.2f);
        sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, 1f);
        yield return new WaitForSeconds(0.2f);
        sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, 0.5f);
        yield return new WaitForSeconds(0.2f);
        sr.material.color = auxiliary;
        isDamageable = true;

    }

    private void Explosion()
    {
        

        /*void OnParticleCollision(GameObject other)
        {
            if (other.tag != this.gameObject.tag)
                Destroy(other.gameObject);
        }*/
    }

    private void OnYandereSimCodeLMAO()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            gm.UpdateHighScore();
        }
    }

    /* private void Dash()
     {

           /* if(direction==0)
         {
             if(moveInputX < 0)
             {
                 direction = 1;
             }
             else if(moveInputX > 0)
             {
                 direction = 2;
             }
             else if(moveInputY )
         }
         }

             if (timeBtwDashes <= 0)
             {
                 canDash = true;

             rb.velocity = Vector2.zero;


             }
             else
             {
                 timeBtwDashes -= Time.deltaTime;
             }

         if(canDash)
         {
             if(Input.GetKeyDown(KeyCode.LeftShift))
             {
                // rb.velocity = Vector2.zero;
                 timeBtwDashes = startTimeBtwDashes;
                 Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
                 // direction = direction.normalized;
                 //direction = direction.normalized;
                 rb.velocity = direction * dashSpeed;
                 rb.AddForce(direction * dashSpeed);
                 canDash = false;
             }
         }

     }*/

    public void Heal(int amount)
    {
        health += amount;
    }
    
    public float GetHealthRatio()
    {
        return (float)((float)health) / ((float)maxHealth);
    }
}
