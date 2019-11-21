using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ConversationsManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Lua.RegisterFunction("OpenConversation", this, SymbolExtensions.GetMethodInfo(() => OpenConversation(string.Empty, double.NaN, double.NaN, double.NaN)));

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenConversation(string conversationName, double playerIndex, double conversantIndex, double dialogEntryIndex) {

        int player = (int)playerIndex;
        int conversant = (int)conversantIndex;
        int dialogEntry = (int)dialogEntryIndex;

        if(PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry(conversationName)) {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation(conversationName, Characters.charactersTransform[player], Characters.charactersTransform[conversant], dialogEntry);
        }
    }
}
