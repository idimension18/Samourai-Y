using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float[] sequence;
    Animator animator;
    [SerializeField] private LevelScript level;

    void Start()
    {
        int bpm = level.getBPM();
        float pas = 60f/bpm;

        StartCoroutine(Beats(pas));
        StartCoroutine(Shoot(pas));
        animator = GetComponent<Animator>();
    }

    IEnumerator Beats(float pas)
    {
        while (true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Beats");
            yield return new WaitForSeconds(pas);
        }
    }

    IEnumerator Shoot(float pas)
    {
        //metronome
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Metronome/Itchi");
        yield return new WaitForSeconds(pas*2); //
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Metronome/Ni");
        yield return new WaitForSeconds(pas*2); //
        
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Metronome/Itchi");
        yield return new WaitForSeconds(pas); //
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Metronome/Ni");
        yield return new WaitForSeconds(pas); //
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Metronome/San");
        yield return new WaitForSeconds(pas); //
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Metronome/Yon");
        yield return new WaitForSeconds(pas); //

        for (int j=0; j<level.getNbrEnnemies(); j++)
        {
            sequence = level.getEnemyList()[j].getTimings();
            Debug.Log(sequence);
            
            //preview du son
            float temps_restant = 4 * pas; //temps d'attente apr�s la derni�re note de la s�quence
            for (int i = 0; i < sequence.Length; i++)
            {
                yield return new WaitForSeconds(sequence[i] * pas); //
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/PreviewR");
                temps_restant -= sequence[i] * pas;
            }
            yield return new WaitForSeconds(temps_restant);
            
            //shoot
            temps_restant = 4 * pas; //temps d'attente apr�s la derni�re note de la s�quence
            for (int i = 0; i < sequence.Length; i++)
            {
                yield return new WaitForSeconds(sequence[i] * pas); //
                GameObject bullet = transform.GetChild(0).gameObject;
                GameObject clone = Instantiate(bullet);
                clone.transform.position = bullet.transform.position + Vector3.left;
                clone.SetActive(true);
                animator.SetTrigger("Shoot");
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/BulletR");
                Debug.Log("Shoot after " + sequence[i].ToString() + " seconds");
                temps_restant -= sequence[i] * pas;
            }
            yield return new WaitForSeconds(temps_restant);
            //mort des ennemis
            animator.SetTrigger("Die");
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
    }

}
