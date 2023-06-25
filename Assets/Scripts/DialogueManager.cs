using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;


public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Story story;
    private bool dialogueIsPlaying;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void EnterDialogueMode(TextAsset inkJSON, string characterName) {
    //     if (dialogueIsPlaying) {
    //         return;
    //     }
    //     else {
    //         story = new Story(inkJSON.text);
    //         playerCurrentlySpeakingTo = characterName;
    //         dialogueIsPlaying = true;
    //         QuestManager.Instance.dialogueVariables.StartListening(story);
    //         //speakers.SetActive(true);
    //         dialoguePanel.SetActive(true);
    //         dialogueBox.SetActive(true);
    //         inventoryBtn.SetActive(false);
    //         journalBtn.SetActive(false);
    //         ContinueStory();
    //         //Audio start dialogue event
    //         dialogueSFX.start();

    //     }
    // }
}
