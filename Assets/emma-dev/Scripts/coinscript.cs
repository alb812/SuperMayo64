using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinscript : MonoBehaviour
{
    public float pickupWaitTime = 1f;
	public float rotateSpeed = 3;

	
	void Update () {
        transform.Rotate(new Vector3(0,rotateSpeed,0));

        if (pickupWaitTime > 0)
        {
            pickupWaitTime -= Time.deltaTime;
        }
    }

	private void OnTriggerStay(Collider other)
	{
        if (pickupWaitTime <= 0)
        {
            if (other.tag == "Player")
            {
                //calling function and then destroying self
                if (this.CompareTag("coin"))
                {
                    //Audio
                    AudioManager.Instance.PlayYellowCoinSound();

                    coinsUI.me.FoundACoin();
                    /*if (livesUI.liveslived < 3)
                   {
                        livesUI.liveslived++;
                   }*/

                    if (marioHealthDeath.health < 8)
                    {
                        marioHealthDeath.health++;
                    }
                }

                if (this.CompareTag("redcoin"))
                {
                    //Audio
                    AudioManager.Instance.PlayRedCoinSound();

                    coinsUI.me.FoundACoin();
                    coinsUI.me.FoundACoin();
                    coinsUI.me.FoundRedCoin();
                    /*if (livesUI.liveslived < 3)
                    {
                        livesUI.liveslived++;
                    }*/

                    if (marioHealthDeath.health < 8)
                    {
                        marioHealthDeath.health += 2;
                    }
                }

                Destroy(this.gameObject);


            }
        }
        	
	}
	
}
