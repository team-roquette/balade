using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenConversation(string conversationName, Transform player, Transform conversant, int dialogEntry) {
        if(PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry(conversationName)) {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation(conversationName, player, conversant, dialogEntry);
        }
    }
}
