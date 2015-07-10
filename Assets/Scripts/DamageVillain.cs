using UnityEngine;
using System.Collections;

   //[RequireComponent(typeof(VillainControls))]
    public class DamageVillain : MonoBehaviour
    {
        //public VillainPhysics playerScript;
        [SerializeField]public float DamageToGive = 1;
        void OnTriggerEnter(Collider other)
        {
           //var play = other.GetComponent<Platformer2DUserControl>();
            if (other.gameObject.tag == "Icecles")
            {
                Debug.Log("Damage Done On VILLAIN");
                //playerScript.TakeDamage(DamageToGive);
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "HomingMissile")
            {
                Debug.Log("Damage Done On VILLAIN");
                //playerScript.TakeDamage(DamageToGive);
                Destroy(other.gameObject);
            }
        }
    }

