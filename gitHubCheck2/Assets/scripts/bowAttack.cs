using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowAttack : MonoBehaviour
{
    public GameObject arrow;
    public Transform shotPoint;

    public PlayerMovement playerMovement;

    public float shootingTimer;
    public float resetShootingTimer;
  
    public float launchForce;
    public float maxLauncForce;
    private float timer;
    public float timerReset;

    public bool isShooting;
    public bool isMaxForce;
    public bool canPlayStrech = false;


    // Update is called once per frame
    private void Start()
    {
        launchForce = 10f;
        shootingTimer = 0f;
        isShooting = false;
        timer = timerReset;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (((Input.GetButtonDown("bow") && shootingTimer <= 0f) || (Input.GetButton("bow") && shootingTimer <= 0f)) && (launchForce < maxLauncForce)) 
        { 
        StartCoroutine(BowStrechSfx());
     
        }
   
        shootingTimer -= Time.deltaTime;

        if ((Input.GetButtonDown("bow") && shootingTimer <= 0f) || (Input.GetButton("bow") && shootingTimer <= 0f))
        {
           
            isShooting = true;
            if (launchForce < maxLauncForce)
            {
                isMaxForce = false;
                launchForce += Time.deltaTime * 14f;
            }
            else
            {
                isMaxForce = true;
                shootingTimer = resetShootingTimer;
                Shoot();
                launchForce = 10f;

            }
        }
        else if (Input.GetButtonUp("bow") && shootingTimer <= 0f)
        {
            shootingTimer = resetShootingTimer;
            Shoot();
            isShooting = false;
            launchForce = 10f;
        }
        else 
        {
            isShooting = false;
        }

     


    }

    void Shoot()
    {
        
        GameObject newArrow = Instantiate(arrow, shotPoint.position, Quaternion.identity);
        Rigidbody2D arrowRigidbody = newArrow.GetComponent<Rigidbody2D>();

        if (playerMovement.isFacingRight)
        {
            arrowRigidbody.velocity = transform.right * launchForce;
            Vector3 scale = newArrow.transform.localScale;
            scale.x = 1;
            newArrow.transform.localScale = scale;
        }
        else
        {
            arrowRigidbody.velocity = transform.right * -launchForce;
            Vector3 scale = newArrow.transform.localScale;
            scale.x = -1;
            newArrow.transform.localScale = scale;
        }

        
    }

    public IEnumerator BowStrechSfx()
    {
            canPlayStrech = true;
            yield return new WaitForSeconds(0.01f);
            canPlayStrech = false;
    }

}
