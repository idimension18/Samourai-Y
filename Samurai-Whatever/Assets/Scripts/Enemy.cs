using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float[] _sequence;
    Animator animator;

    public bool isClear;

    void Start()
    {
        GenerateSequence();
        StartCoroutine(Shoot(2f));
        animator = GetComponent<Animator>();
    }

    void GenerateSequence()
    {
        switch(GlobalVariables.difficulty) {
            case 0:
                _sequence = new float[3];
                _sequence[0] = 1f;
                _sequence[1] = 1f;
                _sequence[2] = 1f;
                break;
            case 1:
                _sequence[0] = 1f;
                _sequence[1] = 1.5f;
                _sequence[2] = 2f;
                _sequence[3] = 2.5f;
                _sequence[4] = 3f;
                break;
        }
    }

    IEnumerator Shoot(float delay)
    {
        for (int i = 0; i < _sequence.Length; i++)
        {
            yield return new WaitForSeconds(_sequence[i]);
            GameObject bullet = transform.GetChild(0).gameObject;
            GameObject clone = Instantiate(bullet);
            clone.transform.position= bullet.transform.position + Vector3.left;
            clone.SetActive(true);

            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/PreviewR");
            Debug.Log("Shoot after " + _sequence[i].ToString() + " seconds");
            animator.SetTrigger("Shoot");

        }
    }

}
