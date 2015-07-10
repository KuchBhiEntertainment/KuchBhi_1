using UnityEngine;
using System.Collections;

    public class GameMaster : MonoBehaviour
    {
        public static void KillPlayer(PlayerStats player)
        {
            Destroy(player.gameObject);
            Application.LoadLevel(1);
        }
    }
