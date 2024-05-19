using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Snake.Player{
    public class Tail:MonoBehaviour {

        [Header("Cola")]
        [SerializeField] GameObject tail;

        List<GameObject> tails=new List<GameObject>();
        private Vector3 last_position;//ultima posicion
        private bool lengthen_tail;//alargar la cola
        Player_controller player_controller;

        private void Start(){
            player_controller=GetComponent<Player_controller>();
        }

        public void set_lengthen_tail(){
            lengthen_tail=true;
        }

        public void movement_tails(Vector3 last_head_position){
            if(tails.Count<1){
                last_position=last_head_position;
            }else{
                if(tails.Count==1){
                    last_position=tails[0].transform.position;
                    tails[0].transform.position=last_head_position;
                }else{
                    for(int i=tails.Count-1; i>=1; i--){
                        if(i==tails.Count-1){
                            last_position=tails[i].transform.position;
                        }

                        tails[i].transform.position=tails[i-1].transform.position;
                    }

                    tails[0].transform.position=last_head_position;
                }
            }

            if(lengthen_tail){
                GameObject new_tail_part=Instantiate(tail,last_position,Quaternion.identity);
                tails.Add(new_tail_part);
                lengthen_tail=false;
            }
        }
    }
}