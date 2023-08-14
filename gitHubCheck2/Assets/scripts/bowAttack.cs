using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowAttack : MonoBehaviour
{
    public GameObject arrow;
    public Transform shotPoint;
    public Transform pointTrans;

    public PlayerMovement playerMovement;

    public float shootingTimer;
    public float resetShootingTimer;

    public float launchForce;
    public float maxLauncForce = 500f;
    private float timer;
    public float timerReset ;

    public bool isShooting;
    public bool isMaxForce;
    public bool canPlayStrech = false;
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoint;

    Vector2 direction;


    // Update is called once per frame
    private void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, pointTrans.position, Quaternion.identity);
        }
        launchForce = 10f;
        shootingTimer = 0f;
        isShooting = false;
        timer = timerReset;
    }
    Vector2 PointPoisition(float t)
    {
        if (playerMovement.isFacingRight)
        {
            Vector2 position = (Vector2)pointTrans.position + direction.normalized  * (launchForce * t) + /*0.5f **/ Physics2D.gravity * (t/* * t*/);
            return position;
        }
        else
        {
            Vector2 position = (Vector2)pointTrans.position + direction.normalized * -1 * (launchForce * t) + /*0.5f **/ Physics2D.gravity * (t /** t*/);
            return position;
        }
    }

    void Update()
    {
        if (!PauseMenu.isPaused && !ShopController.isShoped) { 
            direction = shotPoint.position;
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

            if (Input.GetButtonDown("bow") || Input.GetButton("bow"))
            {
                for (int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = PointPoisition(i * spaceBetweenPoint);
                }

            }
            else 
            {
                for (int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = Vector2.zero;
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
        }

        IEnumerator BowStrechSfx()
        {
            canPlayStrech = true;
            yield return new WaitForSeconds(0.01f);
            canPlayStrech = false;
        }

    }
}