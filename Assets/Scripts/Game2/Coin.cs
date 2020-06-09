using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] AudioClip coinSound;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.Instance.AddCoinCount();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        LevelManager.Instance.RemoveCoinCount();
        AudioManager.Instance.PlaySound(coinSound);

        Destroy(gameObject);
    }
}
