[<RequireQualifiedAccess>]
module AdventOfCode21.List

open AdventOfCode21.Math

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

let median (list: int64 list) =
    list
    |> List.sort
    |> List.map float
    |> function
        | [] -> 0.
        | list ->
            let i = (((list |> List.length) + 1) / 2) - 1

            if i |> isEven then
                list |> List.item i
            else
                [ list |> List.item i; list |> List.item (i + 1) ]
                |> List.average
