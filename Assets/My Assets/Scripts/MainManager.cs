using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // ストーリーの作成
    StoryData.Story story1 = new StoryData.Story
    {
        characterName = "キャラクターA",
        mainText = "こんにちは、選択肢を選んでください。",
        nextStoryIndices = new List<int> { 1, 2 } // 選択肢1と選択肢2に対応
    };

    StoryData.Story story2 = new StoryData.Story
    {
        characterName = "キャラクターB",
        mainText = "選択肢1が選ばれました。",
        nextStoryIndices = new List<int> { 3 } // ストーリー3に進む
    };

    StoryData.Story story3 = new StoryData.Story
    {
        characterName = "キャラクターC",
        mainText = "選択肢2が選ばれました。",
        nextStoryIndices = new List<int> { 4 } // ストーリー4に進む
    };

    // 選択肢の作成
    StoryData.Choice choice1 = new StoryData.Choice
    {
        text = "選択肢1",
        nextStoryIndex = 3
    };

    StoryData.Choice choice2 = new StoryData.Choice
    {
        text = "選択肢2",
        nextStoryIndex = 4
    };

}
