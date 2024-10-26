using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine.UIElements;

public partial struct MySystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> localTranform, RefRO<MyComponent> component) 
            in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MyComponent>>())
        {
            localTranform.ValueRW = localTranform.ValueRW.RotateY(component.ValueRO.Value * SystemAPI.Time.DeltaTime);
        }
    }
}