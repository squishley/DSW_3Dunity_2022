using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] Prompt prompt;
    [SerializeField] Spawner spawner;
    
    bool isClicked = false;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(transform.position, interactionPointRadius, colliders, interactableMask);

        /*if(numFound > 0)
        {
            prompt.showPrompt = true;
        }
        else
        {
            prompt.showPrompt = false;
        }*/

        prompt.showPrompt = numFound > 0 ? true : false;

        // INTERAZZION!

        if(Input.GetKeyDown(KeyCode.F) && !isClicked && numFound > 0 )//&& spawner.isGameStarted == false)
        {
            isClicked = true;
            spawner.isGameStarted = !spawner.isGameStarted;
            StartCoroutine(spawner.waitSpawner());
        }

        if(Input.GetKeyUp(KeyCode.F) && isClicked)
        {
            isClicked = false;
        }
    }
}
