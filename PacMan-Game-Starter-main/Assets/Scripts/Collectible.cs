using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Collectible : MonoBehaviour
{
    AudioSource myaudio;
    // Start is called before the first frame update
    void Start()
    {
        myaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 0.1f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //myaudio.Play();
            //Destroy(gameObject);
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer c in allRenderers) c.enabled = false;
            Collider[] allColliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allColliders) c.enabled = false;
            StartCoroutine(PlayandDestroy(myaudio.clip.length));
        }
    }

    private IEnumerator PlayandDestroy(float waitline)
    {
        myaudio.Play();
        yield return new WaitForSeconds(waitline);
        Destroy(gameObject);
    }
}
