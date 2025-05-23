using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New StoryData", menuName = "Story/StoryData")]
public class StoryData : ScriptableObject
{
    [System.Serializable]
    public class Story
    {
        public string characterName;
        [TextArea]
        public string mainText;
        public Sprite backGround;
        public Sprite characterImageRight;
        public Sprite characterImageLeft;
        public AudioClip se;
        public List<int> nextStoryIndices;
        
    }
    
    public List<Choice> choices;
    public List<Story> stories;

    [System.Serializable]
    public class Choice
    {
        public TextMeshProUGUI buttonText; // ボタンのTextMeshProUGUIコンポーネント
        public string text; // 表示するテキスト
        public int nextStoryIndex; // 次に進むストーリーのインデックス
    }

}


