using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Player{
    public class Player_controller:MonoBehaviour {

        private enum Direction{
            Left,
            Up, 
            Right,
            Down,
        }

        [Header("Frecuencia")]
        [SerializeField] float frequency;

        Direction new_direction=Direction.Up;
        Direction current_direction=Direction.Up;
        Tail tail;

        private void Start(){
            tail=GetComponent<Tail>();
            tail.movement_tails(gameObject.transform.position);
            InvokeRepeating(nameof(movement), 0.5f, frequency);
        }

        void Update() {
            set_direction();
        }

        private void set_direction(){//establecer movimiento
            if(validate_keys(KeyCode.A,KeyCode.LeftArrow)){
                new_direction = Direction.Left;
            }else{
                if(validate_keys(KeyCode.W,KeyCode.UpArrow)){
                    new_direction=Direction.Up;
                }else{
                    if(validate_keys(KeyCode.D,KeyCode.RightArrow)){
                        new_direction=Direction.Right;
                    }else{
                        if(validate_keys(KeyCode.S,KeyCode.DownArrow)){
                            new_direction=Direction.Down;
                        }
                    }
                }
            }
        }

        private bool validate_keys(KeyCode k1,KeyCode k2) {//validate_keys=validar teclas
            return Input.GetKey(k1)||Input.GetKey(k2);
        }

        private void movement(){
            switch(new_direction) {
                case Direction.Left:
                    if(current_direction==Direction.Right){
                        move(Vector2.right);
                    }else{
                        current_direction=new_direction;
                        move(Vector2.left);
                    }
                break;

                case Direction.Up:
                    if(current_direction==Direction.Down) {
                        move(Vector2.down);
                    }else{
                        current_direction=new_direction;
                        move(Vector2.up);
                    }
                break;

                case Direction.Right:
                    if(current_direction==Direction.Left) {
                        move(Vector2.left);
                    } else {
                        current_direction=new_direction;
                        move(Vector2.right);
                    }
                break;

                case Direction.Down:
                    if(current_direction==Direction.Up) {
                        move(Vector2.up);
                    } else {
                        current_direction=new_direction;
                        move(Vector2.down);
                    }
                break;
            }
        }

        private void move(Vector2 position){
            Vector3 position_head = transform.position;
            transform.Translate(position);
            tail.movement_tails(position_head);
        }

        public void cancel_move(){
            CancelInvoke(nameof(movement));
        }
    }
}