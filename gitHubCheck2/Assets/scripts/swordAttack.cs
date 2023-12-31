using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttack : MonoBehaviour
{
    private bool canAttack = true;
    private bool isReseting = false;
    public bool isAttacking = false;
    private bool wasAttacking = false;
    public bool isKilling = false;
    public bool hitEnemy = false;

    //sword attacks bools
    public bool canPlaySwordAttack1 = false;
    public bool canPlaySwordAttack2 = false;
    public bool canPlaySwordAttack3 = false;
    public bool canPlayBoom = false;

    public int attackNum = 0;
    private float resetAttackTime = 1.25f;
    public PlayerMovement player;
    private GameObject camera;
    private Animator shakeAnimator;
    //public Animator lightAnimator;
    public Animator exposureAnimator;
    public GameObject lightningExp;

    public slot slot;

    // Start is called before the first frame update
    void Start()
    {
        //lightningExp.SetActive(false);
        attackNum = 0;
        camera = GameObject.Find("MainCamera");
        shakeAnimator = camera.GetComponent<Animator>();
    }
    //dvir start attack animation where isKilling = true
    //dvir start attack animation where isKilling = true
    //dvir start attack animation where isKilling = true
    //dvir start attack animation where isKilling = true

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused && !ShopController.isShoped) { 
            if (attackNum > 3)
            {
                StartCoroutine(attackR());
            }
            //Debug.Log(attackNum);
            if (Input.GetButtonDown("sword") && !isAttacking && canAttack)
            {
                StartCoroutine(attack());
            }
        }
    }
    //coroutine not stopping when attacking in combo
    private IEnumerator attack()
    {

            isAttacking = true;


            attackNum++;
            if (attackNum == 1)
            {
                canPlaySwordAttack1 = true;
                yield return new WaitForSeconds(0.01f);
                canPlaySwordAttack1 = false;
                yield return new WaitForSeconds(0.15f);
                isKilling = true;
                yield return new WaitForSeconds(0.30f);

            }

            else if (attackNum == 2)
            {
                canPlaySwordAttack2 = true;
                yield return new WaitForSeconds(0.01f);
                canPlaySwordAttack2 = false;
                yield return new WaitForSeconds(0.05f);
                isKilling = true;
                yield return new WaitForSeconds(0.25f);
            }

            else if (attackNum == 3)
            {
                canPlaySwordAttack3 = true;
                yield return new WaitForSeconds(0.01f);
                canPlaySwordAttack3 = false;
                yield return new WaitForSeconds(.75f);
                canPlayBoom = true;
                yield return new WaitForSeconds(0.001f);
                canPlayBoom = false;
                shakeAnimator.SetBool("robotShake", true);
                //lightAnimator.SetBool("lightning", true);
                exposureAnimator.SetBool("lightning", true);
                //lightningExp.SetActive(true);
                isKilling = true;
                yield return new WaitForSeconds(.25f);
            }
            exposureAnimator.SetBool("lightning", false);
            //lightningExp.SetActive(false);
            //lightAnimator.SetBool("lightning", false);
            isAttacking = false;
            shakeAnimator.SetBool("robotShake", false);
            isKilling = false;
            if (isReseting)
            {
                wasAttacking = true;
            }
            StartCoroutine(attackReset());
            yield return new WaitForSeconds(0.1f);
        
    }
    private IEnumerator attackReset()
    {
        isReseting = true;
        yield return new WaitForSeconds(resetAttackTime);
        if (!isAttacking && !wasAttacking)
        {

            StartCoroutine(attackR());
        }
        else
        {
            wasAttacking = false;
            isReseting = false;
            yield return null;
        }
        isReseting = false;
    }
    private IEnumerator attackR()
    {
        attackNum = 0;
        canAttack = false;
        yield return new WaitForSeconds(0.05f);
        canAttack = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyLayer"))
        {
            if (isKilling)
            {
                Debug.Log("gghhh");
                hitEnemy = true;
            }
            else
            {
                hitEnemy = false;
            }
        }
    }






}