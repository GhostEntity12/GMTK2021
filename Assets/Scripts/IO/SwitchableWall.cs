using UnityEngine;

public class SwitchableWall : OutputObject
{
	public Material redMat;
	public Material blueMat;
	public bool isBlue;
	new MeshRenderer renderer;

	private void Awake()
	{
		renderer = GetComponent<MeshRenderer>();
		renderer.material = isBlue ? blueMat : redMat;
		gameObject.layer = isBlue ? 7 : 6;
	}

	public override void Trigger() => Toggle();

	public override void Untrigger() => Toggle();

	void Toggle()
	{
		isBlue = !isBlue;
		renderer.material = isBlue ? blueMat : redMat;
		gameObject.layer = isBlue ? 7 : 6;
	}
}
