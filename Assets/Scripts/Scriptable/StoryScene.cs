using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
public class StoryScene : ScriptableObject
{
    public List<Sentence> Sentences;
    public Sprite background;
    public StoryScene nextScene;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speaker speaker;
        public Sprite sprite;

        public string gameSceneMover;
        public bool isBackToMain;
    }
}
