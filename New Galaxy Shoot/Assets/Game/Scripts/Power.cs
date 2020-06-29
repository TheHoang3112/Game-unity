using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private int powerupID; // 0: triple_shot 1: SpeedPower  2: shields

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);   
    }
    // va cham player vs powerup
    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                if(powerupID == 0)
                {
                    player.TripleShotPowerOn();
                }
                else if (powerupID == 1)
                {
                    player.CanSpeedPowerOn();
                    Debug.Log("CanSpeedBoost: " + other.name);
                }
                else if (powerupID == 2)
                {
                    player.CanShieldsPowerOn();
                }
                
            }
            Destroy(this.gameObject);
        }
    }
}
