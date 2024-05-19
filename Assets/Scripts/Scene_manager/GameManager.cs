using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Snake.Scene_manager{
    public class GameManager:MonoBehaviour{

        private static GameManager instance;
        
        public static GameManager get_instance{
            get{ 
                return instance; 
            }
        }

        private void Awake(){
            if(instance==null){
                instance=this;
                DontDestroyOnLoad(gameObject);
            }else{
                Destroy(gameObject);
            }
        }

        public void new_game(){
            Game_score.get_instance.new_game();
            SceneManager.LoadScene(1);
        }

        public void game_over(){
            Game_score.get_instance.game_over();
            SceneManager.LoadScene(0);
        }
    }
}