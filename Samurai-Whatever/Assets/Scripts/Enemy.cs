using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float[] sequence;
    [SerializeField] private LevelScript level;

    void Start()
    {
        int bpm = level.getBPM();
        float pas = 60f/bpm;
        StartCoroutine(Shoot(pas));
    }

    IEnumerator Shoot(float pas)
    {
        //metronome
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Preview2L");
        yield return new WaitForSeconds(pas); //
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Preview2L");
        yield return new WaitForSeconds(pas); //
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Preview2L");
        yield return new WaitForSeconds(pas); //
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Preview2L");
        yield return new WaitForSeconds(pas); //

        for (int j=0; j<level.getNbrEnnemies(); j++)
        {
            sequence = level.getEnemyList()[j].getTimings();
            Debug.Log(sequence);
            
            //preview du son
            float temps_restant = 4 * pas; //temps d'attente après la dernière note de la séquence
            for (int i = 0; i < sequence.Length; i++)
            {
                yield return new WaitForSeconds(sequence[i] * pas); //
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/PreviewR");
                temps_restant -= sequence[i] * pas;
            }
            yield return new WaitForSeconds(temps_restant);
            
            //shoot
            temps_restant = 4 * pas; //temps d'attente après la dernière note de la séquence
            for (int i = 0; i < sequence.Length; i++)
            {
                yield return new WaitForSeconds(sequence[i] * pas); //
                GameObject bullet = transform.GetChild(0).gameObject;
                GameObject clone = Instantiate(bullet);
                clone.transform.position = bullet.transform.position + Vector3.left;
                clone.SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/BulletR");
                Debug.Log("Shoot after " + sequence[i].ToString() + " seconds");
                temps_restant -= sequence[i] * pas;
            }
            yield return new WaitForSeconds(temps_restant);
            //mort des ennemis
        }
    }

}
