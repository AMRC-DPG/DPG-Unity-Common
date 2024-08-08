# DPG-Unity-Common

<!-- TOC -->
* [DPG-Unity-Common](#dpg-unity-common)
  * [Runtime](#runtime)
    * [Singletons](#singletons)
<!-- TOC -->

## Runtime

### [Singletons](https://github.com/AMRC-DPG/DPG-Unity-Common/tree/67c0c7c390846d374a374738f69ef3b58b84ce54/Runtime/Singletons)

An abstract base class to provide the logic for the Singleton Pattern to the subclass component.

<details><summary>Example</summary>

```csharp
public class Sounds : Singleton<Sounds>
{
    protected override void Awake()
    {
        // Custom code
        
        base.Awake();
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        throw new NotImplementedException();
    }
}
```

</details>

It also provides functionality to choose (from the editor) whether the subclass is destroyed on load or not.

![singleton.png](~Images\singleton.png)
