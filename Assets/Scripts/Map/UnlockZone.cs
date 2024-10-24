using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnlockZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartUnlocking()
    {
        StartCoroutine(Unlock());
    }

    public IEnumerator Unlock()
    {
        List<Transform> transforms = transform.GetComponentsInChildren<Transform>().ToList<Transform>();
        while (transforms.Count > 0)
        {
            yield return new WaitForSeconds(Random.value / 5);
            int idx = Random.Range(0, transforms.Count);
            Transform transformPicked = transforms[idx];
            if (transform != transformPicked)
            {
                StartCoroutine(Fade(transformPicked, Random.value / 50));
            }
            transforms.RemoveAt(idx);
        }
    }

    IEnumerator Fade(Transform t, float fadeTimeout)
    {
        MeshRenderer renderer = t.gameObject.GetComponent<MeshRenderer>();
        Color c = renderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.01f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(fadeTimeout);
        }
        Destroy(t.gameObject);
    }
}
