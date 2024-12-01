using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public static int score;
    [SerializeField] private float cooldown = 0.1f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

    public static Vector3 pos;
    private WaitForSeconds Delay;

    private InputSystem_Actions inputs;
    [SerializeField] private Collider2D fireLGO;
    [SerializeField] private Collider2D fireRGO;
    [SerializeField] private Collider2D fireTopGO;

    void Awake()
    {
        score = 0;
        Delay = new WaitForSeconds(cooldown);
        inputs = new InputSystem_Actions();
        pos = transform.position;

        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        inputs.PlayerSlash.FireL.Enable();
        inputs.PlayerSlash.FireR.Enable();
        inputs.PlayerSlash.FireTop.Enable();
    }

    private void Start()
    {
        inputs.PlayerSlash.FireL.started += context => { animator.SetTrigger("Slash"); StartCoroutine(InputCoroutine(fireLGO)); sprite.flipX = false; };
        inputs.PlayerSlash.FireR.started += context => { animator.SetTrigger("Slash"); StartCoroutine(InputCoroutine(fireRGO)); sprite.flipX = true; };
        inputs.PlayerSlash.FireTop.started += context => StartCoroutine(InputCoroutine(fireTopGO));
    }



    IEnumerator InputCoroutine(Collider2D coll)
    {
        coll.gameObject.SetActive(true);
        yield return Delay;
        coll.gameObject.SetActive(false);
    }


}
