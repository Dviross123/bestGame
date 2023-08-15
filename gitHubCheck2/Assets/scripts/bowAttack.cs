using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowAttack : MonoBehaviour
{
    public GameObject arrow;
    public Transform shotPoint;

    public float shootingTimer;
    public float resetShootingTimer;

    public float launchForce;
    public float maxLauncForce = 500f;
    private float timer;
    public float timerReset;

    public bool isShooting;
    public bool isMaxForce;
    public bool canPlayStrech = false;




    Vector2 direction;



    private void Start()
    {


        launchForce = 10f;
        shootingTimer = 0f;
        isShooting = false;
        timer = timerReset;
    }


    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if (!PauseMenu.isPaused && !ShopController.isShoped)
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
                    launchForce += Time.deltaTime * 50f;
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

                GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

               

            }
        }

        IEnumerator BowStrechSfx()
        {
            canPlayStrech = true;
            yield return new WaitForSeconds(0.01f);
            canPlayStrech = false;
        }

    }
