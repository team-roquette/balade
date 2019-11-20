using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoyfriendComment : MonoBehaviour
{
    public string conversationName; 
    public double playerIndex; 
    public double conversantIndex;
    public int dialogEntryIndex;
    public ConversationsManager conversationsManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Boyfriend") {
            conversationsManager.OpenConversation(conversationName, playerIndex, conversantIndex, dialogEntryIndex);
        }
    }
}
