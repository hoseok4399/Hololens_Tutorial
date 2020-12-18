using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

    namespace Hoseok{
    public class SoundManager : MonoBehaviour {   
        public GameObject lights;
          
        KeywordRecognizer voiceCommands;

        void Start() {
            voiceCommands = new KeywordRecognizer(new string[] {"명령어1","명령어2"});
            voiceCommands.OnPhraseRecognized += VoiceCommands_OnPhraseRecognized;
            voiceCommands.Start();
        }

        void Update() {

            if (Input.GetKeyDown(KeyCode.I) == true)
            {
                //명령함수 집어넣으세요
            }
            else if (Input.GetKeyDown(KeyCode.O) == true)
            {
                //명령함수 집어넣으세요
            }
        
        }
        private void VoiceCommands_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
            if (args.text == "명령어1") 
            {
                //명령함수 집어넣으세요
            } 
            else if (args.text == "명령어2")
            {
                //명령함수 집어넣으세요
            }
        }
    }
}
