using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // �X�g�[���[�̍쐬
    StoryData.Story story1 = new StoryData.Story
    {
        characterName = "�L�����N�^�[A",
        mainText = "����ɂ��́A�I������I��ł��������B",
        nextStoryIndices = new List<int> { 1, 2 } // �I����1�ƑI����2�ɑΉ�
    };

    StoryData.Story story2 = new StoryData.Story
    {
        characterName = "�L�����N�^�[B",
        mainText = "�I����1���I�΂�܂����B",
        nextStoryIndices = new List<int> { 3 } // �X�g�[���[3�ɐi��
    };

    StoryData.Story story3 = new StoryData.Story
    {
        characterName = "�L�����N�^�[C",
        mainText = "�I����2���I�΂�܂����B",
        nextStoryIndices = new List<int> { 4 } // �X�g�[���[4�ɐi��
    };

    // �I�����̍쐬
    StoryData.Choice choice1 = new StoryData.Choice
    {
        text = "�I����1",
        nextStoryIndex = 3
    };

    StoryData.Choice choice2 = new StoryData.Choice
    {
        text = "�I����2",
        nextStoryIndex = 4
    };

}
