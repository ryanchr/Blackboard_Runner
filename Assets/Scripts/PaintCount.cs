using UnityEngine;
using System.Collections;

public class PaintCount : MonoBehaviour {
	private Sprite[] spPaintCountPic;
	private SpriteRenderer spriteRenderer;
	private int iPaintCount;
	public static PaintCount Instance;

	// Use this for initialization
	void Start () {
		Instance = this;
		iPaintCount = 10;
		spPaintCountPic = Resources.LoadAll<Sprite> ("paintCount");
		spriteRenderer = GetComponent<SpriteRenderer>();
		UpdatePic ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPaint(int iNum) {
		iPaintCount += iNum;
		iPaintCount = (iPaintCount > 10) ? 10 : iPaintCount;
		UpdatePic ();
	}

	public void RmPaint(int iNum) {
		iPaintCount -= iNum;
		iPaintCount = (iPaintCount < 0) ? 0 : iPaintCount;
		UpdatePic ();
	}

	private void UpdatePic() {
		spriteRenderer.sprite = spPaintCountPic [iPaintCount];
	}

	public int getNumberOfPaint()
	{
		return iPaintCount;
	}

	public bool IfHasPaint() {
		if (iPaintCount > 0) {
			return true;
		} else {
			return false;
		}
	}
}
