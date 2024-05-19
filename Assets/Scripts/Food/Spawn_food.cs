using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Food{
    public class Spawn_food:MonoBehaviour {
        [Header("Comida")]
        [SerializeField] GameObject food;

        [Header("Limites")]
        [SerializeField] GameObject bottom_limit;
        [SerializeField] GameObject top_limit;
        [SerializeField] GameObject left_limit;
        [SerializeField] GameObject right_limit;

        private float min_position_x, max_position_x, min_position_y, max_position_y;

        void Start(){
            calculate_limits();
        }

        private void calculate_limits(){//calcular límites
            float size_food_x = food.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            float size_food_y = food.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

            min_position_x=left_limit.transform.position.x
                            +(left_limit.GetComponent<SpriteRenderer>().sprite.bounds.size.x/2)
                            +(size_food_x/2);

            max_position_x=right_limit.transform.position.x
                            -(right_limit.GetComponent<SpriteRenderer>().sprite.bounds.size.x/2)
                            -(size_food_x/2);

            min_position_y=bottom_limit.transform.position.y
                            +(bottom_limit.GetComponent<SpriteRenderer>().sprite.bounds.size.y/2)
                            +(size_food_y/2);

            max_position_y=top_limit.transform.position.y
                            -(top_limit.GetComponent<SpriteRenderer>().sprite.bounds.size.y/2)
                            -(size_food_y/2);

            Invoke(nameof(spawn_food),2f);
        }

        private void spawn_food(){//generar comida
            int postion_x=(int) Random.Range(min_position_x, max_position_x);
            int postion_y=(int) Random.Range(min_position_y, max_position_y);

            float new_postion_x=postion_x+0.5f;
            float new_postion_y=postion_y+0.5f;

            if(new_postion_x>max_position_x){
                new_postion_x=postion_x-0.5f;
            }

            if(new_postion_y>max_position_y){
                new_postion_x=postion_x-0.5f;
            }

            food.transform.position=new Vector2(new_postion_x,new_postion_y);
            food.SetActive(true);
        }

        public void eaten(){//comido
            food.SetActive(false);
            Invoke(nameof(spawn_food),1f);
        }
    }
}