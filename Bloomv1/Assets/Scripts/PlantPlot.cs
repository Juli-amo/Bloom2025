using UnityEngine;

public class PlantPlot : MonoBehaviour
{
    public enum State { Empty, Seed, Healthy, Invasive }
    public State state = State.Empty;

    public Color empty = new(0.55f,0.55f,0.55f);
    public Color seed  = new(0.70f,0.90f,0.70f);
    public Color healthy = new(0.40f,0.80f,0.40f);
    public Color invasive = new(1.00f,0.40f,0.80f);

    [Range(0,100)] public int water = 0;
    public int healthyThreshold = 30, invasiveThreshold = 70;

    bool inRange; SpriteRenderer sr;

    void Awake(){ sr = GetComponent<SpriteRenderer>(); UpdateVisual(); }
    void Update(){ if(inRange && Input.GetKeyDown(KeyCode.E)) Interact(); }

    void Interact(){
        if(state==State.Empty){ state=State.Seed; water=0; }
        else water = Mathf.Clamp(water+15,0,100);
        if(water>=invasiveThreshold) state=State.Invasive;
        else if(water>=healthyThreshold) state=State.Healthy;
        else state=State.Seed;
        UpdateVisual();
    }

    void UpdateVisual(){
        sr.color = state switch{
            State.Empty=>empty, State.Seed=>seed, State.Healthy=>healthy, _=>invasive};
    }

    void OnTriggerEnter2D(Collider2D c){ if(c.CompareTag("Player")) inRange=true; }
    void OnTriggerExit2D(Collider2D c){ if(c.CompareTag("Player")) inRange=false; }
}