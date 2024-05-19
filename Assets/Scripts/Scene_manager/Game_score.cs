using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Scene_manager{
    public class Game_score:MonoBehaviour {
        private const string BEST_SCORE_KEY="Maxima puntuacion";
        private const string LAST_SCORE_KEY="Ultima puntuacion";

        private int best_score;
        private int last_score;
        private int current_points;

        private static Game_score instance;

        public static Game_score get_instance{ 
            get{
                return instance;
            } 
        }

        private void Awake(){
            if(instance==null){
                instance=this;
                DontDestroyOnLoad(gameObject);
                load_points();
            }else{
                Destroy(gameObject);
            }
        }

        public int get_current_points(){
            return current_points;
        }

        public int get_best_score() {
            return best_score;
        }

        public int get_last_score(){
            return last_score;
        }

        public void game_over(){
            last_score=current_points;
        }

        public void sum_points(){
            current_points++;

            if(current_points>best_score){
                best_score=current_points;
            }
        }

        private void save_points(){
            PlayerPrefs.SetInt(BEST_SCORE_KEY,best_score);
            PlayerPrefs.SetInt(LAST_SCORE_KEY,last_score);
        }

        private void load_points(){
            best_score=PlayerPrefs.GetInt(BEST_SCORE_KEY,0);
            last_score=PlayerPrefs.GetInt(LAST_SCORE_KEY,0);
        }

        public void new_game(){
            current_points=0;
        }

        private void OnApplicationQuit() {
            save_points();
        }

        private void OnApplicationPause(bool pause){
            if(pause){
                save_points();
            }
        }
    }
}