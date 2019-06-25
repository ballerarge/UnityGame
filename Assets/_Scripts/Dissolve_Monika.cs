using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve_Monika : MonoBehaviour {
	private Material mat;
	private Material[] matArr;
	private Renderer rend;

	[Header("Set in Inspector")]
	public int framesBeforeUpdate;
	public int framesCount;
	public float amountToDissolve;
	public Shader dissolveShader;
	public Material matToCopy;
	public Texture tex;

    private void Start() {
        framesCount=0;
      	rend = GetComponent<Renderer>();
      	matArr = rend.materials;
      	for (int i = 0; i < matArr.Length; i++) {
      		matArr[i].shader = dissolveShader;
      		// matArr[i].CopyPropertiesFromMaterial(matToCopy);
      		matArr[i].SetTexture("_DissolveMap", tex);
      	}
      	rend.materials = matArr;

    }

    private void Update() {
    	framesCount++;
        //mat.SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);
        if (framesCount >= framesBeforeUpdate) {
        	//mat.SetFloat("_DissolveAmount", mat.GetFloat("_DissolveAmount") + amountToDissolve);
        	matArr = rend.materials;
        	for (int i = 0; i < matArr.Length; i++) {
	        	matArr[i].SetFloat("_DissolveAmount", matArr[i].GetFloat("_DissolveAmount") + amountToDissolve);
	        	rend.materials = matArr;
	        	framesCount=0;
        	}
        }
        
    }
}
