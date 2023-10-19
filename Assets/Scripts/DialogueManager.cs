using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{

    //public variables
    public static DialogueManager Instance;
    //private variables
    private Story story;
    private float textSpeedInMilSecs;
    private bool dialogueIsPlaying;
    private bool isTyping;
    private const string SPEED = "speed";
    private List<string> tags;
    //serialized fields
    [SerializeField] private TMP_Text textBody;
    [SerializeField] private TMP_Text skipInstructions;
    [SerializeField] private TextAsset inkStory;
    [SerializeField] private Button continueBtn;

    private void Awake() {
        if (Instance != null) {
            Debug.Log("More than One Dialogue Manager Instance Present");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        //textBody = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
        //inputProvider.FindActionMap("UIActions").FindAction("Skip Dialogue").performed += UpdateDialogueSystem;
        tags = new List<string>();
        isTyping = false;
        continueBtn.gameObject.SetActive(false);
        skipInstructions.gameObject.SetActive(false);

    }

    void Start() {
        EnterSceneTransitionMonologueMode(inkStory);
    }

    void Update() {
        if(Input.GetButtonDown("Jump")) {
            SkipCurrentText();
        }
    }

    public void EnterSceneTransitionMonologueMode(TextAsset inkJSON) {
        if (dialogueIsPlaying) {
            return;
        }
        else {
            story = new Story(inkJSON.text);
            int dayVal = GameManager.Instance.DayCount;
            story.variablesState["dayVal"] = dayVal;
            dialogueIsPlaying = true;
            //speakers.SetActive(true);
            ContinueStory();

        }
    }

    private void ExitSceneTransitionMonologueMode() {
        dialogueIsPlaying = false;
        textBody.text = "";
    }

    private void SkipCurrentText() {
        skipInstructions.gameObject.SetActive(false);
        if (!dialogueIsPlaying) {
            return;
        }
        ContinueStory();
    }

    //might have to modify to cater the needs
    private void ContinueStory() {
        if (!story.canContinue && !isTyping) {
            ExitSceneTransitionMonologueMode();
            return;
        }
        else if (isTyping) {
            StopAllCoroutines();
            textBody.text = story.currentText;
            isTyping = false;
        }
        else {
            story.Continue();
            ManageTags();
            StartCoroutine(DisplayText(story.currentText));
        }
    }

    private IEnumerator DisplayText(string currentText)
    {
        textBody.text = "";
        isTyping = true;
        char[] textArray = currentText.ToCharArray();
        foreach (char letter in textArray)
        {
            textBody.text += letter;
            yield return new WaitForSeconds(textSpeedInMilSecs);
        }
        if(!story.canContinue)
        {
            //continue btn display should be in continueStory when the ink Story has finished
            continueBtn.gameObject.SetActive(true);
        }
        else {
            skipInstructions.gameObject.SetActive(true);
        }
        isTyping = false;
        yield return null;
    }

    private void ManageTags() {
        tags = story.currentTags;
        foreach (var tag in tags) {
            if (tag.Split(":").Length != 2) {
                Debug.Log("Tag Incorrect :" + tag);
            }
            string tagKey = tag.Split(":")[0].Trim();
            string tagValue = tag.Split(":")[1].Trim();

            switch (tagKey) {
                case SPEED:
                    SetTextSpeed(float.Parse(tagValue));
                    break;
                default:
                    break;
            }
        }
    }

    private void SetTextSpeed(float speedVal) {
        textSpeedInMilSecs = speedVal * 0.001f;
    }

    //add skip btn if necessary
}
