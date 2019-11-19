using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoyfriendComment : MonoBehaviour
{
    private Transform player; 
    private Transform boyfriend;
    public string conversationName; 
    public int dialogEntry;
    public ConversationsManager conversationsManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        boyfriend = GameObject.Find("Boyfriend").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Boyfriend") {
            conversationsManager.OpenConversation(conversationName, player, boyfriend, dialogEntry);
        }
    }
}
