using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float[] sequence;

    void Start()
    {
        GenerateSequence();
        StartCoroutine(Shoot(2f));
    }

    void Update()
    {
        
    }

    void GenerateSequence()
    {
        switch(GlobalVariables.difficulty) {
            case 0:
                sequence = new float[3];
                sequence[0] = 1f;
                sequence[1] = 1f;
                sequence[2] = 1f;
                break;
            case 1:
                sequence[0] = 1f;
                sequence[1] = 1.5f;
                sequence[2] = 2f;
                sequence[3] = 2.5f;
                sequence[4] = 3f;
                break;
        }
    }

    IEnumerator Shoot(float delay)
    {
        for (int i = 0; i < sequence.Length; i++)
        {
            yield return new WaitForSeconds(sequence[i]);
            GameObject bullet = transform.GetChild(0).gameObject;
            GameObject clone = Instantiate(bullet);
            clone.transform.position= bullet.transform.position + Vector3.left;
            clone.SetActive(true);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/PreviewR");
            Debug.Log("Shoot after " + sequence[i].ToString() + " seconds");
        }
    }

}
