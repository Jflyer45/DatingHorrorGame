using UnityEngine;
using System.Collections;

public class drunk : MonoBehaviour 
{
	public Material material0;
	public Material material1;
	public Material material2;

	public  int drunkLevel = -1;
	public Material currentMaterial;

    private void Start()
    {
        this.enabled = false;
    }



    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, currentMaterial);
    }

	public void ChangeDrunkLevel()
    {
		drunkLevel += 1;

        this.enabled = true;

		if (drunkLevel == 0)
        {
			currentMaterial = material0;
        }else if(drunkLevel == 1)
        {
			currentMaterial = material1;
        }
        else if (drunkLevel == 2)
        {
			currentMaterial = material2;
        }
    }
}