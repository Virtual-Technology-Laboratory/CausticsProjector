using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CausticsPlayer : MonoBehaviour
{
    Projector projector;
    int frame = 0;
    int numFrames = 60;
    int frameRate = 60;
    List<Texture> renderedFrames;


    // Use this for initialization
    void Start()
    {
        projector = GetComponent<Projector>();
        renderedFrames = new List<Texture>();

        for (int i = 0; i < numFrames; i++)
        {
            renderedFrames.Add(Resources.Load<Texture>(string.Format("CausticsRender_{0:D3}", i + 1)));
        }

        StartCoroutine("UpdateFrame");

    }

    // Update is called once per frame
    IEnumerator UpdateFrame()
    {
        while (true)
        {
            projector.material.SetTexture("_ShadowTex", renderedFrames[frame]);
            frame = (frame + 1) % numFrames;
            yield return new WaitForSeconds(1f / frameRate);
        }

    }
}
