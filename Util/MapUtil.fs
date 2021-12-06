[<RequireQualifiedAccess>]
module AdventOfCode21.Map

let mapAt key mapper map =
    map |> Map.map (fun k v -> if k = key then mapper v else v)

let inc key map = map |> mapAt key (fun i -> i + 1)
