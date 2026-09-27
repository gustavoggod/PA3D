using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{

    private int Coin = 0;

    public TextMeshProUGUI cointText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Coin++;
            cointText.text = "Coin: " + Coin.ToString();
            Debug.Log("Coins: " + Coin);
            Destroy(other.gameObject);
        }
    }
}
