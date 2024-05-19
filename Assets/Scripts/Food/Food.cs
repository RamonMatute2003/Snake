using Snake.Player;
using Snake.Scene_manager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Snake.Food{
    public class Food:MonoBehaviour {
        [Header("Generador de comida")]
        [SerializeField] Spawn_food spawn_food;

        Player_controller player_Controller;
        Tail tail;

        private void Start() {
            player_Controller=gameObject.GetComponent<Player_controller>();
            tail=gameObject.GetComponent<Tail>();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.CompareTag("Food")){
                Game_score.get_instance.sum_points();
                spawn_food.eaten();
                tail.set_lengthen_tail();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if(collision.gameObject.CompareTag("Limit") || collision.gameObject.CompareTag("Tail")){
                GameManager.get_instance.game_over();
                player_Controller.cancel_move();
            }
        }
    }
}