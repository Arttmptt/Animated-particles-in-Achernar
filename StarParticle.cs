using UnityEngine;

public class StarParticle : MonoBehaviour
{
    public float scale = 1f;
    public float randScale;
    public float speed;

    private void Update()
    {
        if (speed == -0.03f) // for static stars
            gameObject.transform.localPosition += new Vector3 (speed * Time.deltaTime, (speed / 2.5f) * Time.deltaTime, 0);
        else
            gameObject.transform.localPosition += gameObject.transform.up * Time.deltaTime * speed;

        // this is need for animation of particles' scale with Unity Animation
        gameObject.transform.localScale = new Vector3 (scale + randScale, scale + randScale, gameObject.transform.localScale.z);
    }
}
