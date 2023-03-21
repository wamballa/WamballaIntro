using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("Trigger enter " + collision.transform.position + " " + collision.transform.name);
            dialogueManager.StartDialogue(dialogue);
        }

    }

}
