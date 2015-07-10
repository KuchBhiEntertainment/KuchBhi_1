using UnityEngine;
using System.Collections;

    public class PlayerStats : MonoBehaviour
    {
        [System.Serializable]
        public class PlayerStatistics
        {
            public int Health = 100;
        }
        public PlayerStatistics playerStats = new PlayerStatistics();
        public int yLimit = -50;
        void Update()
        {
            if (transform.position.y <= yLimit)
            {
                DamagePlayer(9999999);
            }
        }

        public void DamagePlayer(int damage)
        {
            playerStats.Health -= damage;
            if (playerStats.Health <= 0)
            {
                GameMaster.KillPlayer(this);
            }
        }
    }

