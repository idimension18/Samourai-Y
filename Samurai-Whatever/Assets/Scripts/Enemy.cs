using System;
using System.Collections;
using UnityEditor.TerrainTools;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private float[] _sequence;
    Animator animator;
    [SerializeField] private LevelScript level;
    public bool isClear;
    private Vector3 _reverseVector= new Vector3(-1,1,1);
    static private bool jouer_metronome = true; 
    [SerializeField] private GameObject metronome_visu;
    static public event Action OnLevelClear;

    void Start()
    {
        isClear = false;
        int bpm = level.getBPM();
        float pas = 60f/bpm;
        Animator animator_metronome = metronome_visu.GetComponent<Animator>();

        StartCoroutine(Beats(pas, animator_metronome));
        StartCoroutine(Shoot(pas));
        animator = GetComponent<Animator>();
    }

    IEnumerator Beats(float pas, Animator animator_metronome)
    {
        while (jouer_metronome)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Preview2L");
            animator_metronome.SetTrigger("beat");
            yield return new WaitForSeconds(pas);
        }
        
    }
    public void SetLevel(LevelScript lvl)
    {
        this.level = lvl;
    }

    IEnumerator Shoot(float pas)
    {
        //Variables
        EnemyScript currentEnemy;

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
            _sequence = level.getEnemyList()[j].getTimings();
            currentEnemy = level.getEnemyList()[j];
            
            //preview du son
            float temps_restant = 4 * pas; //temps d'attente apr�s la derni�re note de la s�quence
            for (int i = 0; i < _sequence.Length; i++)
            {
                yield return new WaitForSeconds(_sequence[i] * pas); //
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/PreviewR");
                temps_restant -= _sequence[i] * pas;
            }
            yield return new WaitForSeconds(temps_restant);
            
            //shoot
            temps_restant = 4 * pas; //temps d'attente apr�s la derni�re note de la s�quence
            for (int i = 0; i < _sequence.Length; i++)
            {
                yield return new WaitForSeconds(_sequence[i] * pas); //
                GameObject bullet = transform.GetChild(0).gameObject;
                GameObject clone = Instantiate(bullet);
                clone.transform.position = bullet.transform.position + Vector3.left;
                clone.SetActive(true);
                animator.SetTrigger("Shoot");
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/BulletR");
                Debug.Log("Shoot after " + _sequence[i].ToString() + " seconds");
                temps_restant -= _sequence[i] * pas;
            }
            yield return new WaitForSeconds(temps_restant);

            //mort des ennemis
            float bpm = 60f / pas;
            if (bpm<120f)
            {
                temps_restant = 4 * pas;
            } else
            {
                temps_restant = 8 * pas;
            }
            temps_restant = 4 * pas;
            animator.SetTrigger("Die");
            OnLevelClear.Invoke();
            yield return new WaitForSeconds(1f);
            temps_restant -= 1f;


            //spawn de l'ennemi suivant
            if (j< level.getNbrEnnemies()-1) //on vérifie que l'ennemi n'est pas le dernier ennemi
            {
                
                if (currentEnemy.getRight()) //Si l'ennemi est à droite 
                {
                    Vector3 from = new Vector3(5.5f, 0.71f, 0f);
                    Vector3 to = new Vector3(2.71f, 0.71f, 0f);
                    transform.position = from;
                    animator.SetTrigger("Idle");
                    yield return new WaitForSeconds(0.5f);
                    temps_restant -= 0.5f;
                    float temps_passe = 0;
                    float duree_deplacement = 1.5f * pas;

                    while (temps_passe < duree_deplacement)
                    {
                        float t = temps_passe / duree_deplacement;
                        transform.position = Vector3.Lerp(from, to, t);
                        temps_passe += Time.deltaTime;
                        temps_restant -= Time.deltaTime;
                        yield return null;
                    }
                }
            }
            yield return new WaitForSeconds(temps_restant); //On attend pour que le tout dure une mesure

        }
        jouer_metronome = false;
    }

    void Update()
    {
        if (this.transform.position.x > 0 || this.transform.localScale.x>0)
        {
            this.transform.localScale = _reverseVector;
        }
    }
    public IEnumerator WaitCompletion()
    {
        Debug.Log("Waiting defeat");

        while (!isClear)
        {
            yield return null;
        }

        Debug.Log("Enemy Defeated");
    }
}
