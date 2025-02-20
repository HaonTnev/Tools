using Haon.Utils;
using UnityEngine;

public class highlitedablests : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(gameObject.LerpTowards(new Vector3(10, 10, 10), 4.0f));
    }
}
