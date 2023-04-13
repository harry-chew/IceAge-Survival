using UnityEngine;

public interface IFauna
{
    void Eat();
    void Sleep();
    void MoveTo(Vector3 position);
    void Attack();
    void Defecate();
}