using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public GameObject grain;

    public int startingPoints = 10;
    public int pointsDropPerStage = 2;

    public Material grainGrow0;
    public float grainGrow0Timeout = 60f;
    public Material grainGrow1;
    public float grainGrow1Timeout = 60f;
    public Material grainGrow2;
    public float grainGrow2Timeout = 60f;
    public Material grainGrow3;
    public float grainGrow3Timeout = 60f;
    public Material grainGrow4;
    public Material grainDryed0;
    public float grainDryedTimeout = 60f;
    public Material grainDryed1;
    public Material grainGathered;
    public float grainGatheredTimeout = 60f;

    [SerializeField] private int state = 0;
    [SerializeField] private int currentPoints = 0;
    [SerializeField] private float stateTiemout = 0;
    private Score score;
    private FarmMinigameDirector miniGameDirector;
    private MeshRenderer grainMeshRenderer;

    private List<int> collectibleStates;
    private List<int> idleStates;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        Restart();
    }


    void Initialize() {
        miniGameDirector = GameObject.FindGameObjectWithTag("MinigameEventSystem").GetComponent<FarmMinigameDirector>();
        score = miniGameDirector.GetComponent<Score>();
        grainMeshRenderer = grain.GetComponent<MeshRenderer>();

        collectibleStates = new List<int> {5, 7, 8};
        idleStates = new List<int> {0, 5, 8};
    }

    public void Restart()
    {
        state = 0;
        currentPoints = startingPoints;
        grain.SetActive(false);
    }

    void OnMouseDown()
    {
        PlotInteract();
    }

    void FixedUpdate() {
        if (!idleStates.Contains(state)) {
            stateTiemout -= Time.fixedDeltaTime;
            if (stateTiemout <= 0) {
                TimerExpired();
            }
        }
    }


    void TimerExpired() {
        switch (state) {
            case 1:
                state = 2;
                stateTiemout = grainGrow1Timeout;
                grainMeshRenderer.material = grainGrow1;
                break;
            case 2:
                state = 3;
                stateTiemout = grainGrow2Timeout;
                grainMeshRenderer.material = grainGrow2;
                break;
            case 3:
                state = 4;
                stateTiemout = grainGrow3Timeout;
                currentPoints -= pointsDropPerStage;
                grainMeshRenderer.material = grainGrow3;
                break;
            case 4:
                state = 5;
                currentPoints -= pointsDropPerStage;
                grainMeshRenderer.material = grainGrow4;
                break;
            case 6:
                state = 7;
                stateTiemout = grainDryedTimeout;
                grainMeshRenderer.material = grainDryed0;
                break;
            case 7:
                state = 8;
                currentPoints -= pointsDropPerStage;
                grainMeshRenderer.material = grainDryed1;
                break;
            default:
                break;
        }
    }

    public void PlotInteract() {
        switch (state) {
            case 0:
                state = 1;
                currentPoints = startingPoints;
                stateTiemout = grainGrow0Timeout;
                grainMeshRenderer.material = grainGrow0;
                grain.SetActive(true);
                break;
            case 3:
                state = 6;
                stateTiemout = grainGatheredTimeout;
                grainMeshRenderer.material = grainGathered;
                break;
            case 4:
                state = 6;
                stateTiemout = grainGatheredTimeout;
                grainMeshRenderer.material = grainGathered;
                break;
            case var _ when collectibleStates.Contains(state):
                state = 0;
                score.GainScore(currentPoints);
                grain.SetActive(false);
                break;
            default:
                break;
        }
    }
}
