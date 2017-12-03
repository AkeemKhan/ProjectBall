using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //Damage Stats
    public float damagePerSecond;
    public float damageRadius;
    public float abilityRequirement;
    public float abilityEnergy = 0;
    public float abilityMaxEnergy = 5;


    //Utility Stats
    public float maxHealth = 20;
    public float currentHealth = 20;
    public float jumpSpeed;
    public float jumpRequirement;
    public float speed;
    public float maxSpeed;
    public float abilityEnergyReq = 3;
    public float abilityEnergyDeminishingGain = 0.1f;
    public float abilityEnergyBonusRegen = 0f;

    //Ability Stats

    //Blast
    public float blastDamage;
    public float blastRadius;
    public float blastForce;
    public float blastRequirements;
    public float blastCooldown;

    //Rush
    public float rushForce;
    public float rushRequirements;
    public float rushRadius;

    //Projectile
    public float projectileSpeed;
    public float projectileDamage;
    public float projectRequirements;
    public float projectileRange;

    public bool requiresGrounded = true;
    private bool grounded;
    private bool freeze = false;
    private float gravityCounter;

    private Vector3 UIMovement = new Vector3(0, 0, 0);

    private bool canJump = true;
    private bool engageUIMovement = false;

    //Game Objects
    public GameObject shockWave;
    public GameObject energyBar;
    public GameObject healthBar;
    public GameObject playerCannon;
    private Rigidbody rb;
    private LevelController lcontroller;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ExecuteAbilities();
        syncHealth();
        EnergyRegen();
        CheckJump();
        Movement();
        MovementByUI();
    }

    void OnCollisionEnter(Collision col)
    {
        if(requiresGrounded)
        {
            if (col.transform.tag == "Ground")
                grounded = true;
        }
            
    }

    void OnCollisionExit(Collision col)
    {
        if (col.transform.tag == "Ground")
            grounded = false;
    }

    public void GravityManipulation()
    {
        gravityCounter += Time.deltaTime;
        if (gravityCounter > 0.5)
            transform.GetComponent<Rigidbody>().isKinematic = true;
        else
            transform.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Movement()
    {
        //if (grounded)
        //    transform.GetComponent<Rigidbody>().useGravity = false;
        //else
        //    transform.GetComponent<Rigidbody>().useGravity = true;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
      
        rb.AddForce(movement * speed);
    }

    public void CheckJump()
    {
        float moveJump = Input.GetAxis("Jump");
        if(requiresGrounded == true)
        {
            if (moveJump > 0 && grounded)
            {
                Jump();
            }
        }
        else
        {
            if (moveJump > 0)
            {
                Jump();
            }
        }
        
    }

    public void Jump()
    {
        if (abilityEnergy > jumpRequirement)
        {

            Vector3 movement = new Vector3(0.0f, 1, 0.0f);

            rb.AddForce(movement * jumpSpeed);
            abilityEnergy -= jumpRequirement;
        }
    }

    public void MoveUp()
    {
        engageUIMovement = true;
        UIMovement = new Vector3(0, 0, 1);
    }

    public void MoveDown()
    {
        engageUIMovement = true;
        UIMovement = new Vector3(0, 0, -1);
    }

    public void MoveLeft()
    {
        engageUIMovement = true;
        UIMovement = new Vector3(-1, 0, 0);
    }

    public void MoveRight()
    {
        engageUIMovement = true;
        UIMovement = new Vector3(1, 0, 0);
    }

    public void StopMovement()
    {
        engageUIMovement = false;
    }

    public void MovementByUI()
    {
        if(engageUIMovement)
            rb.AddForce(UIMovement * speed);
    }




    //Health and Energy

    public void EnergyRegen()
    {
        if (abilityEnergy < abilityMaxEnergy)
            abilityEnergy += Time.deltaTime+(abilityEnergyBonusRegen* Time.deltaTime);

        energyBar.GetComponent<Slider>().minValue = 0;
        energyBar.GetComponent<Slider>().value = abilityEnergy;
        energyBar.GetComponent<Slider>().maxValue = abilityMaxEnergy;
    }

    public void syncHealth()
    {
        healthBar.GetComponent<Slider>().maxValue = maxHealth;
        healthBar.GetComponent<Slider>().value = currentHealth;
        if(currentHealth <= 0)
        {
            lcontroller = new LevelController();
            lcontroller.scene = SceneManager.GetActiveScene().buildIndex;
            lcontroller.LoadScene();
        }
    }

    public void InstantHeal(float value)
    {
        currentHealth += value + 50;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void DamagePlayer(float damage)
    {
        currentHealth = currentHealth - damage;
    }



    //Buffs
    public void BuffStats()
    {
        maxHealth += 25;
        abilityEnergyDeminishingGain *= 2;
        speed += 5;
        GameObject.Find("PlayerLight").GetComponent<Light>().intensity *= 1.5f;
    }

    public void MinorBuff()
    {
        BuffEnergy(1);
        BuffSpeed(1);
        BuffLight(1.1f);
        BuffDamage(2);
        BuffDamageRadius(2);
        abilityEnergy = abilityMaxEnergy;
    }

    public void MajorBuff()
    {
        BuffHealth(50);
        BuffEnergy(5);
        BuffSpeed(5);
        BuffLight(1.5f);
        BuffDamage(5);
        BuffDamageRadius(5);
    }
    public void BuffLight(float buff)
    {
        GameObject.Find("PlayerLight").GetComponent<Light>().intensity *= buff;
    }

    public void BuffHealth(int buff)
    {
        maxHealth += buff;
        currentHealth += buff;
    }

    public void BuffEnergy(int buff)
    {
        abilityMaxEnergy += buff;
        abilityEnergyBonusRegen += 0.01f;
    }

    public void BuffSpeed(int buff)
    {
        speed += buff;
    }

    public void BuffDamage(int buff)
    {
        damagePerSecond += buff;
    }

    public void BuffDamageRadius(int buff)
    {
        damageRadius += buff;
    }

    //Abilities

    public void ExecuteAbilities()
    {
        if(abilityEnergy > blastRequirements)
            Player_Blast();

        if (abilityEnergy > rushRequirements)
            Player_Rush();

        Player_Projectile();
        Player_Barrier();
    }

    public void Player_Blast()
    {
        float ability = Input.GetAxis("Shockwave");
        if (ability > 0)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, blastRadius);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            foreach (Collider item in hitColliders)
            {
                if (item.GetComponent<Rigidbody>() != null)
                {
                    item.GetComponent<Rigidbody>().AddExplosionForce(blastForce * 3, transform.position, blastRadius);
                    if (item.tag == "Enemy")
                    {
                        item.GetComponent<EnemyController>().DamageHealth(blastDamage+(damagePerSecond+abilityEnergy)/4);
                    }
                }

            }
            Instantiate(shockWave, transform.position, transform.rotation);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            abilityEnergy = 0;
        }      
    }

    public void Player_Rush()
    {
        float ability = Input.GetAxis("Rush");
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (ability > 0)
        {
            if (moveHorizontal > 0)//Dash Right
            {
                Vector3 movement = new Vector3(moveHorizontal + rushForce, 0.0f, 0);
                rb.AddForce(movement);
            }
            if (moveHorizontal < 0)//Dash Left
            {
                Vector3 movement = new Vector3(moveHorizontal - rushForce, 0.0f, 0);
                rb.AddForce(movement);
            }

            if (moveVertical > 0)//Dash Up
            {
                Vector3 movement = new Vector3(0, 0.0f, moveVertical + rushForce);
                rb.AddForce(movement);
            }
            if (moveVertical < 0)//Dash Up
            {
                Vector3 movement = new Vector3(0, 0.0f, moveVertical - rushForce);
                rb.AddForce(movement);
            }
            abilityEnergy -= rushRequirements;
        }

    }

    public void Player_Projectile()
    {
        float ability = Input.GetAxis("Projectile");
        if (ability > 0 && (abilityEnergy > projectRequirements))
        {
            PlayerCannon pc = playerCannon.GetComponent<PlayerCannon>();
            pc.projectileDamage = projectileDamage;
            pc.projectileRange = projectileRange;
            pc.projectileSpeed = projectileSpeed;
            pc.DetectAndFire();
            abilityEnergy -= projectRequirements;
        }
    }

    public void Player_Barrier()
    {

    }


}