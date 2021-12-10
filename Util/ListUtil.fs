[<RequireQualifiedAccess>]
module AdventOfCode21.List

let countWith f list = list |> List.filter f |> List.length

let countItem item list = list |> countWith ((=) item)

let groupItemCounts list =
    list
    |> List.distinct
    |> List.map (fun item -> item |> withSnd (list |> countItem item))

let mult list = list |> List.fold (*) 1

let mapAt i f list =
    list
    |> List.mapi (fun index item -> if index = i then item |> f else item)

let replaceAt i item list = list |> mapAt i (fun _ -> item)
