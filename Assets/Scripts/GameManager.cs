using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

    namespace Hoseok{
    public class GameManager : MonoBehaviour {
                
           enum GameMode {
            Menu,
            Playing
        }

        KeywordRecognizer voiceCommands;

        public bool clear;
        public int health;
        
        float timer;
        
        bool bosssummon;
        bool walllose;
        bool bosslife;

        public GameObject zombie;
        public GameObject boss;
        public GameObject Game;
        public GameObject Menu;
        public GameObject LoggerUI;
        public GameObject lights;

        private int kill;
        private GameMode currentGameMode = GameMode.Menu;
        private Logger logger;
        private float timeAfterSpawn;

        void Start() {
            walllose = false;
            clear = false;
            logger = Logger.Instance;
            bosssummon = false;
            bosslife = true;
            health = 100;
            voiceCommands = new KeywordRecognizer(new string[] { "play", "menu", "boom", "heal" ,"lumos", "nox"});
            voiceCommands.OnPhraseRecognized += VoiceCommands_OnPhraseRecognized;
            voiceCommands.Start();

            for (int j = 0; j < LoggerUI.gameObject.transform.childCount; j++)
            {
                GameObject child = LoggerUI.gameObject.transform.GetChild(j).gameObject;
                child.SetActive(false);
            }

            SetGameMode(GameMode.Menu);
        }

        void Update() {
            if (currentGameMode == GameMode.Playing)
            {
            timer += Time.deltaTime;
            timeAfterSpawn += Time.deltaTime;
            }
            updatelog();
            if (timeAfterSpawn >= 0.5 && bosssummon == false)
            {
                 Vector3 position = new Vector3(Random.Range(-1.2f,1.2f), Random.Range(1f,2f), Random.Range(10f,20f));
            Instantiate(boss, position, Quaternion.Euler(0,0,0));
            bosssummon = true;
            }
            
            if (Input.GetKeyDown(KeyCode.M) == true) {
                SetGameMode(GameMode.Menu);

            } else if (Input.GetKeyDown(KeyCode.P) == true) {
                SetGameMode(GameMode.Playing);
            } 
            else if (Input.GetKeyDown(KeyCode.L) == true)
            {
                Camera.main.GetComponent<Bombcreate>().create();
            }
             else if (Input.GetKeyDown(KeyCode.H) == true)
            {
                Camera.main.GetComponent<Bombcreate>().heal();
            }
            else if (Input.GetKeyDown(KeyCode.I) == true)
            {
                lights.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.O) == true)
            {
                lights.SetActive(false);  
            }
        }

        public void updatelog(){
            if(health <0)
            logger.Log($"Game Over");
            else if( bosslife == false )
            {
            clear = true;
            SetGameMode(GameMode.Menu);
            }
            // 맵 밖을 벗어났을 경우 패배에 대한 조건입니다
            else if ((Camera.main.transform.position.x > 2 || Camera.main.transform.position.x < -2)||
            ( Camera.main.transform.position.z < -3|| Camera.main.transform.position.z > 27))
            {
                walllose = true;

            SetGameMode(GameMode.Menu);
            }
            // 현재의 Hp, Time 시간에 대해 알려줍니다

            else
            logger.Log($"Hp: {health}, Timer: {timer}");
            

        }
        public void ShowGame() {
            SetGameMode(GameMode.Playing);
        }

        public void ShowMenu() {
            SetGameMode(GameMode.Menu);
        }

        private void VoiceCommands_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
            if (args.text == "play") {
                SetGameMode(GameMode.Playing);
            } else if (args.text == "menu") {
                SetGameMode(GameMode.Menu);
            }
            else if(args.text == "boom") {
                Camera.main.GetComponent<Bombcreate>().create();
            }
            else if(args.text == "heal") {
                Camera.main.GetComponent<Bombcreate>().heal();
            }
            else if(args.text == "lumos") {
                lights.SetActive(true);}
            else if(args.text == "nox"){
                lights.SetActive(false);}    
        }

        void SetGameMode(GameMode modeToSet) {
            if(clear == true)
            logger.Log($"Mission Clear!");
            else if (walllose == true)
            logger.Log($"You banned rule, You lose");
            else
            logger.Log($"SetGameMode {modeToSet}");

            currentGameMode = modeToSet;

            if (currentGameMode == GameMode.Playing) {
                
                PointerUtils.SetHandRayPointerBehavior(PointerBehavior.AlwaysOff);
                InvokeRepeating("spawn", 10f, 8f);
            }
            
            if (currentGameMode == GameMode.Menu ) {
                
                PointerUtils.SetHandRayPointerBehavior(PointerBehavior.Default);
                CancelInvoke("spawn");
            }

            Menu.SetActive(currentGameMode == GameMode.Menu);
            Game.SetActive(currentGameMode == GameMode.Playing);
        }

        void spawn()
        {
            Vector3 position = new Vector3(Random.Range(-2f,2f), Random.Range(1f,3f), Random.Range(-2f,27f));
            Instantiate(zombie, position, Quaternion.Euler(0,0,0));
        }

        public void bossdie()
        {
            bosslife = false;
        }

        public void zombieAttack(bool zombieIsThere)
        {
            health -= 5;
        }

        public void bossAttack()
        {
            health -= 35;
        }

       
        
    }
    }