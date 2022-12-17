using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialoge : MonoBehaviour
{
    public GameObject dialoguePanel;
    //public KeyCode contkey;
    public Button contButton;
    public TMP_Text text;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerisclose;


    private void Awake()
    {
        contButton = GetComponent<Button>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(contkey))
        //{ 
        //    contButton.onClick.Invoke();
        //}
        if (Input.GetKeyDown(KeyCode.E) && playerisclose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                Zerotext();
            }
            else
            { 
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        //if (text.text == dialogue[index])
        //{
        //    continueButton.SetActive(true);
        //}
    }

    public void Zerotext()
    {
        text.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        //continueButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            text.text = "";
            StartCoroutine(Typing());
        }
        else 
        {
            Zerotext();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            playerisclose = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerisclose = false;
            Zerotext();
        }
    }
}
