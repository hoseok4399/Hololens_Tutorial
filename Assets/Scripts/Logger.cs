using TMPro;
using UnityEngine;

namespace Hoseok{
    /// play에 관하여 점수를 남기는 부분입니다.
    public class Logger : MonoBehaviour {
        public TextMeshPro textMeshPro;

        private const bool shouldLogToConsole = true;

        private static Logger _Instance;
        public static Logger Instance {
            get {
                if (_Instance == null) {
                    _Instance = FindObjectOfType<Logger>();
                }

                return _Instance;
            }
        }

        void Start() {
        }

        void Update() {

        }

        /// <summary>
        /// Logs the message to the UI and the console.
        /// </summary>
        /// <remarks>
        /// This should be called from the main thread only! If you want to call it from another thread, then update this method.
        /// </remarks>
        /// <returns>The feedback text control if it found it</returns>
        public void Log(string message) {
            if (textMeshPro.isActiveAndEnabled) {
                textMeshPro.SetText(message);
            }
            if (shouldLogToConsole && !message.Contains("diff")) {
                // Debug.Log(message);
            }
        }
    }
}