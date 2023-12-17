using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{

    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode jump;
    [SerializeField] KeyCode attack;
    [SerializeField] KeyCode run;


    public KeyCode Up() { return up; }
    public KeyCode Down() { return down; }
    public KeyCode Left() { return left; }
    public KeyCode Right() { return right; }
    public KeyCode Jump() { return jump; }
    public KeyCode Attack() { return attack; }
    public KeyCode Run() { return run; }


    public void SetUp(KeyCode code) { this.up = code; }
    public void SetDown(KeyCode code) { this.down = code; }
    public void SetLeft(KeyCode code) { this.left = code; }
    public void SetRight(KeyCode code) { this.right = code; }
    public void SetJump(KeyCode code) { this.jump = code; }
    public void SetAttack(KeyCode code) { this.attack = code; }
    public void SetRun(Input input, KeyCode code) {this.run = code; }






}
