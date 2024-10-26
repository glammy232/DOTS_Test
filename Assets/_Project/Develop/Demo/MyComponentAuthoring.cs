using UnityEngine;

using Unity.Entities;

public class MyComponentAuthoring : MonoBehaviour
{
    [SerializeField] private float _value;

    private class Baker : Baker<MyComponentAuthoring>
    {
        public override void Bake(MyComponentAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new MyComponent
            {
                Value = authoring._value
            });
        }
    }
}
