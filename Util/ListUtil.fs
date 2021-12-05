[<RequireQualifiedAccess>]
module AdventOfCode21.List

let countWith f list = list |> List.filter f |> List.length

let countItem item list = list |> countWith ((=) item)

let groupItemCounts list =
    list
    |> List.distinct
    |> List.map (fun item -> item |> withSnd (list |> countItem item))
