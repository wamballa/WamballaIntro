using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    //public GameObject[] products;
    public LogoSpawner logoSpawner;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (!hasTriggered) logoSpawner.SpawnLogos();
            hasTriggered = true;
            dialogueManager.StartDialogue(dialogue);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            dialogueManager.EndDialogue();
        }
    }

    //private void SpawnObjects() 
    //{ 
    //    foreach(GameObject go in products)
    //    {
    //        GameObject spawn = Instantiate(go, spawnPoint.position, Quaternion.identity);
    //        Destroy(go, 3);
    //    }
    //}

}
