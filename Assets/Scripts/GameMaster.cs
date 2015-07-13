using UnityEngine;
using System.Collections;

    public class GameMaster : MonoBehaviour
    {
        PenguinController penguin;
        EskimoAI eskimo;
        GameObject player;
        bool penguinDamaged = false;
        bool eskimoDamaged = false;
        float time = 3f;
        float penguinActualSpeed;
        float eskimoActualSpeed;
        void Awake()
        {
            player = GameObject.Find("Penguin");
            penguin = player.GetComponent<PenguinController>();
            eskimo = FindObjectOfType<EskimoAI>().GetComponent<EskimoAI>();
            penguinActualSpeed = penguin.speed;
            eskimoActualSpeed = eskimo.speed;
        }

        public float GetTime()
        {
            return Time.deltaTime;
        }

        public void DoDamageToPenguin(float damageToGive)
        {
            penguin.speed -= damageToGive;
            penguinDamaged = true;
        }

        public void DoDamageToEskimo(float damageToGive)
        {
            eskimo.speed -= damageToGive;
            eskimoDamaged = true;
        }

        public void KillPlayer()
        {
            Destroy(player.gameObject);
            Application.LoadLevel(1);
        }

        void Update()
        {
            time -= Time.deltaTime;
            if(time <=0)
            {
                if (penguinDamaged)
                {
                    penguin.speed = penguinActualSpeed +0.25f;
                    penguinDamaged = false;
                }
                if(eskimoDamaged)
                {
                    eskimo.speed = eskimoActualSpeed + 0.25f;
                    eskimoDamaged = false;
                }
                time = 2f;
            }
        }



    }
