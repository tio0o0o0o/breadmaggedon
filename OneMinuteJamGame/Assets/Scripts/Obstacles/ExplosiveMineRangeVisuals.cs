using UnityEngine;

public class ExplosiveMineRangeVisuals : MonoBehaviour
{
    public GameObject visualizer;
    private ExplosiveMine mine;

    private void Start()
    {
        mine = GetComponent<ExplosiveMine>();
        visualizer.transform.LeanScale(Vector3.one * mine.explosionRange * 2, mine.time).setEaseOutQuad();
    }
}
