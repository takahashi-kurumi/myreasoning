using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using static StoryData;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private StoryData storyData;
    [SerializeField] private Image backGround;
    [SerializeField] private Image characterImageRight;
    [SerializeField] private Image characterImageLeft;
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private AudioSource se;
    [SerializeField] private GameObject SelectButton;
    [SerializeField] private Transform SelectButtons;

    private int currentIndex = 0;

    public int storyIndex { get; private set; }


    void Start()
    {
        ShowStory(currentIndex);
    }




    public void NextStory()
    {

        if (currentIndex < storyData.stories.Count - 1)
        {
            
            ShowStory(currentIndex);
        }

        else if (currentIndex == storyData.stories.Count - 1)
        {
            ShowChoices();
        }
    }

    private void ShowStory(int index)
    {
        Debug.Log(index);
        var story = storyData.stories[index];
        backGround.sprite = story.backGround;
        characterImageRight.sprite = story.characterImageRight;
        characterImageLeft.sprite = story.characterImageLeft;
        mainText.text = story.mainText;
        characterName.text = story.characterName;
        


        if (story.se != null)
        {
            se.PlayOneShot(story.se);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentIndex++;
            mainText.text = "";
            characterName.text = "";
            NextStory();
            //ShowStory(currentIndex);
        }
    }

    private void ShowChoices()
    {
        // �����̑I�����{�^�����폜
        foreach (Transform child in SelectButtons)
        {
            Destroy(child.gameObject);
        }

        // �V�����I�����{�^���𐶐�
        foreach (var choice in storyData.choices)
        {
            Debug.Log(choice.nextStoryIndex);
            var button = Instantiate(SelectButton, SelectButtons);
            var buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = choice.text;
            choice.buttonText = buttonText; // Choice��TextMeshProUGUI���i�[
            button.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(choice));
        }
    }

    private void OnChoiceSelected(StoryData.Choice choice)
    {
        currentIndex = choice.nextStoryIndex;
        ShowStory(currentIndex);
    }

    private void OnChoiceSelected(int nextIndex)
    {
        currentIndex = nextIndex;
        ShowStory(currentIndex);
    }


}
