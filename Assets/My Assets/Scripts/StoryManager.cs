using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
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
    
    private bool isLettering = false; 
    private int currentIndex = 0;

    CancellationTokenSource cts;

    public int storyIndex { get; private set; }


    void Start()
    {
        ShowStory(currentIndex);
    }




    public void NextStory()
    {

        if (storyData.stories[currentIndex].nextStoryIndices != null && storyData.stories[currentIndex].nextStoryIndices.Count > 0)
        {
            ShowStory(currentIndex);
            ShowChoices();
            
        }


        else if (currentIndex <= storyData.stories.Count - 1)
        {

            ShowStory(currentIndex);
            
        }
    }

    private async void ShowStory(int index)
    {
        Debug.Log(index);
        var story = storyData.stories[index];
        backGround.sprite = story.backGround;
        characterImageRight.sprite = story.characterImageRight;
        characterImageLeft.sprite = story.characterImageLeft;
        characterName.text = story.characterName;
        

        if (isLettering)
        {
            if (cts != null)
            {
                cts.Cancel();
                
            }
        }
        else
        {
            cts = new CancellationTokenSource();
            await TypeText(story.mainText, cts.Token);
            
        }

    }

    private async UniTask TypeText(string text, CancellationToken ct)
    {
        isLettering = true;
        try
        {
            await UniTask.Yield();
            mainText.text = "";

            foreach (char letter in text)
            {
                mainText.text += letter;
                await UniTask.Delay(200, false, PlayerLoopTiming.Update, ct);
            }
        }
        catch (OperationCanceledException e)
        {
            mainText.text = text;
        }

        isLettering = false;

        currentIndex++;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //mainText.text = "";
            characterName.text = "";
            NextStory();
            

        }
        
    }



    private void ShowChoices()
    {
        //既存の選択肢ボタンを削除
        foreach (Transform child in SelectButtons)
        {
            Destroy(child.gameObject);
        }

        // 新しい選択肢ボタンを生成
        foreach (var choice in storyData.choices)
        {
            Debug.Log(choice.nextStoryIndex);
            var button = Instantiate(SelectButton, SelectButtons);
            var buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = choice.text;
            choice.buttonText = buttonText; // ChoiceにTextMeshProUGUIを格納
            button.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(choice));
        }
    }

    private void OnChoiceSelected(StoryData.Choice choice)
    {
        foreach (Transform child in SelectButtons)
        {
            Destroy(child.gameObject);
        }
        currentIndex = choice.nextStoryIndex;
        ShowStory(currentIndex);
    }


}
