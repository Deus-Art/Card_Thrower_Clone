using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _gameAssets;

    public static GameAssets gameAssets
    {
        get
        {
            if(_gameAssets == null) _gameAssets = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _gameAssets;
        }
    
    }

        public SoundAudioClip[] soundAudioClipArray;

        [System.Serializable]
        public class SoundAudioClip
        {
            public SoundManager.Sound sound;
            public AudioClip audioClip;
        }
        
}

