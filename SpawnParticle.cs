using System.Collections;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    // prefab
    public GameObject particle;

    private void Start()
    {
        // Static particles
        StartCoroutine (SpawnStatic ());

        // Fast particles in move
        for (int i = 0; i < 11; i++)
        {
            StartCoroutine (SpawnNonStop ());
        }
    }

    IEnumerator SpawnStatic () {
        for (int i = 0; i < 390; i++) {
            Vector3 pos = new Vector3 (0, 0, 0);
            float randScale = 0;

            pos = new Vector3 (Random.Range (-6f, 27f), Random.Range (-3f, 13f), 10);
            randScale = (Random.Range (0, 85) == 0) ? 3f : Random.Range (-0.8f, 1.2f);

            GameObject newParticle = Instantiate (particle, pos, Quaternion.Euler (0, 0, Random.Range (0, 360))) as GameObject;

            newParticle.transform.parent = gameObject.transform;
            newParticle.transform.localPosition = pos;
            newParticle.GetComponent <StarParticle> ().randScale = randScale;
            newParticle.GetComponent <StarParticle> ().speed = -0.03f;

            yield return new WaitForEndOfFrame (); // For cool Random.Range
        }
        yield break;
    }

    IEnumerator SpawnNonStop () {
        Vector3 pos = new Vector3 (0, 0, 0);
        float randScale = 0;

        switch (Random.Range (0, 4)) { // + delay
            case 0:
                yield return new WaitForSeconds (1.5f);
                break;
            case 1:
                yield return new WaitForSeconds (3f);
                break;
            case 3:
                yield return new WaitForSeconds (4.5f);
                break;
        }

        pos = new Vector3 (Random.Range (-6f, 6f), Random.Range (-3.2f, 3.2f), 10);
        randScale = (Random.Range (0, 85) == 0) ? 2.6f : Random.Range (-0.6f, 1.2f);

        GameObject newParticle = Instantiate (particle, pos, Quaternion.Euler (0, 0, Random.Range (0, 360))) as GameObject;

        newParticle.transform.parent = gameObject.transform;
        newParticle.transform.localPosition = pos;
        newParticle.GetComponent <StarParticle> ().randScale = randScale;
        newParticle.GetComponent <StarParticle> ().speed = Random.Range (1.5f, 10f);

        while (true)
        {
            yield return new WaitForSeconds (6f);

            pos = new Vector3 (Random.Range (-8f, 8f), Random.Range (-3.44f, 3.44f), 10);

            newParticle.transform.localPosition = pos;
            newParticle.transform.localRotation = Quaternion.Euler (0, 0, Random.Range (0, 360));
        }
    }
}
