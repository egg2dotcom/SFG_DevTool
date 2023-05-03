using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Image portrait;

    public Animator animator;

    [Space(10)]
    [Range(0.01f, 2f)]
    public float textSpeed; //slider that controls text speed in inspector


    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, Sprite npcportrait)
    {
        animator.SetBool("IsOpen", true);
        
        nameText.text = dialogue.name;

        portrait.sprite = npcportrait; //set custom portrait

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            float textDelay = 0.05f / textSpeed;
            yield return new WaitForSeconds(textDelay); //controls text speed
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}
