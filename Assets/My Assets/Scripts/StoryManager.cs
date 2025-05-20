using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private StoryData storyData;
    [SerializeField] private Image backGround;
    [SerializeField] private Image characterImageRight;
    [SerializeField] private Image characterImageLeft;
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private AudioSource se;

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
            currentIndex++;
            ShowStory(currentIndex);
        }
    }

    private void ShowStory(int index)
    {
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
            ShowStory(currentIndex);
        }
    }
}
