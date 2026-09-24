using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation _treeConversation;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Inside");
        if(other.CompareTag("Player"))
        {
            Debug.Log("Tag detected");
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                Debug.Log("Conversation tigrered");
                ConversationManager.Instance.StartConversation(_treeConversation);
            }
        }
    }
}
