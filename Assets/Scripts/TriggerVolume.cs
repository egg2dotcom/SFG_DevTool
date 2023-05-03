using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public GameObject prompt;
    private bool IsPlayerHere = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(true);
            IsPlayerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(false);
            IsPlayerHere = false;
        }
    }

    private void Update()
    {
        if (IsPlayerHere && Input.GetKeyDown(KeyCode.E))
        {
            dialogueTrigger.TriggerDialogue();
        }
    }

    private void Start()
    {
        prompt.SetActive(false);
    }
}
