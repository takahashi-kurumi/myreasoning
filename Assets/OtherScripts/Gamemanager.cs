using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGame
{
    public class GameManager : MonoBehaviour
    {
        // �ʂ̃N���X����GameManager�̕ϐ��Ȃǂ��g����悤�ɂ��邽�߂̂��́B�i�ύX�͂ł��Ȃ��j
        public static GameManager Instance { get; private set; }

        void Awake()
        {
            // ����ŁA�ʂ̃N���X����GameManager�̕ϐ��Ȃǂ��g����悤�ɂȂ�B
            Instance = this;
        }
    }
}
