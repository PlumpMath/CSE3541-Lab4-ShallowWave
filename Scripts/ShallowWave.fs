namespace ShallowWave
open UnityEngine

type ShallowWave() =
    inherit MonoBehaviour()

    let size = 64
    let rate = 0.005f
    let damping = 0.999f

    let initVertexCoord size index =
        index * 0.2f - size * 0.1f
   
    let initVertices size initFn : Vector3 list =
        [
            for i in 1 .. (size) ->
                new Vector3(initFn i, 0.0f, initFn i)
        ]

    member this.Start() =
        let mutable mesh = this.GetComponent<MeshFilter>().mesh
        mesh.Clear()

        ()
