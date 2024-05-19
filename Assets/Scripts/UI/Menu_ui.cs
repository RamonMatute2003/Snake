using Snake.Scene_manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Snake.UI{
    public class Menu_ui:MonoBehaviour {
        [Header("UI")]
        [SerializeField] Text txt_best_score;
        [SerializeField] Text txt_last_score;

        void Start(){
            txt_best_score.text=Game_score.get_instance.get_best_score().ToString();
            txt_last_score.text=Game_score.get_instance.get_last_score().ToString();
        }

        public void new_game(){
            GameManager.get_instance.new_game();
        }
    }
}