using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText; // Change to TextMeshProUGUI
    public string[] dialogue;
    private int index;
    public int lastLine;

    public GameObject continueButton;
    public float wordSpeed;
    public bool playerIsClose;
    public bool isTalking;


    private void Start()
    {
        lastLine = dialogue.Length -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIsClose)
            isTalking = false;

        if (index < lastLine)
        {

            if (!isTalking && playerIsClose)
            {
                if (dialoguePanel.activeInHierarchy)
                {
                    zeroText();
                }
                else
                {
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing());

                }
            }
            if (dialogueText.text == dialogue[index])
            {
                continueButton.SetActive(true);
                if (!Input.GetKeyDown(KeyCode.A))
                {
                    if (!Input.GetKeyDown(KeyCode.D))
                    {
                        if (Input.anyKeyDown)
                        {
                            NextLine();
                        }
                    }
                }
            }
        }
        else 
        {
            zeroText();
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        isTalking = false;
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            isTalking = true;
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        continueButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            index = 0;  
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}