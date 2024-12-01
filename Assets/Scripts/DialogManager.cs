using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class DialogManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogState
    {
        public string ActiveSpeaker; // Either "Left" or "Right"
        public string LeftCharacterName; // Name of the left character
        public string RightCharacterName; // Name of the right character
        public string DialogText; // The dialog text to display
        public Sprite LeftSprite; // The sprite on the left
        public Sprite RightSprite; // The sprite on the right

        // TODO: implement soon
        // public Sprite Background;
    }

    public string levelScene;

    public TextMeshProUGUI leftNameText; // Text box for the left character's name
    public TextMeshProUGUI rightNameText; // Text box for the right character's name
    public Image leftCharacterImage; // UI image for the left character
    public Image rightCharacterImage; // UI image for the right character
    public TextMeshProUGUI dialogText; // UI text for the dialog
    public DialogState[] dialogStates; // Array of dialog states

    private int currentDialogIndex = 0; // Tracks the current dialog index


    public DialogScriptableObject dialogData;

    private void Start()
    {
        dialogStates = dialogData.dialogStates;
        DisplayDialog();
    }

    private void DisplayDialog()
    {
        if (currentDialogIndex >= dialogStates.Length) return;

        DialogState currentState = dialogStates[currentDialogIndex];

        // Update character sprites
        leftCharacterImage.sprite = currentState.LeftSprite;
        rightCharacterImage.sprite = currentState.RightSprite;

        // Adjust transparency to highlight the active speaker
        leftCharacterImage.color = currentState.ActiveSpeaker == "Left" ? Color.white : new Color(1, 1, 1, 0.5f);
        rightCharacterImage.color = currentState.ActiveSpeaker == "Right" ? Color.white : new Color(1, 1, 1, 0.5f);

        // Show and hide name boxes based on the active speaker
        if (currentState.ActiveSpeaker == "Left")
        {
            leftNameText.text = currentState.LeftCharacterName;
            rightNameText.text = ""; // Hide the right name box text
        }
        else
        {
            rightNameText.text = currentState.RightCharacterName;
            leftNameText.text = ""; // Hide the left name box text
        }

        // Update dialog text
        dialogText.text = currentState.DialogText;
    }


    public void AdvanceDialog()
    {
        currentDialogIndex++;

        if (currentDialogIndex < dialogStates.Length)
        {
            DisplayDialog();
        }
        else
        {
            EndDialog();
        }
    }

    private void EndDialog()
    {
        Debug.Log("Dialog Ended");
        SceneManager.LoadScene(levelScene);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Advance on mouse click
        {
            AdvanceDialog();
        }
    }
}