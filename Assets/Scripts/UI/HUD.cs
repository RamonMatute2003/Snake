using Snake.Scene_manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Snake.UI{
    public class HUD:MonoBehaviour {
        [SerializeField] Text txt_points;
        [SerializeField] Text txt_best_score;
        
        void Start() {
            update_points();
        }

        private void Update() {
            update_points();
        }

        public void update_points(){
            txt_best_score.text="maxima puntuacion "+Game_score.get_instance.get_best_score().ToString();
            txt_points.text=Game_score.get_instance.get_current_points().ToString();        
        }
    }
}

