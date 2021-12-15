[<RequireQualifiedAccess>]
module AdventOfCode21.Map

open Microsoft.FSharp.Collections

let mapAt key mapper map =
    map |> Map.map (fun k v -> if k = key then mapper v else v)

let inc key map = map |> mapAt key (fun i -> i + 1)

let mapAtOrAdd key mapper def map =
    if map |> Map.containsKey key then
        map |> Map.map (fun k v -> if k = key then mapper v else v)
    else
        map |> Map.add key def
