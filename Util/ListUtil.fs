[<RequireQualifiedAccess>]
module AdventOfCode21.List

open AdventOfCode21.Math

let countWhere f list = list |> List.filter f |> List.length

let countItem item list = list |> countWhere ((=) item)

let groupItemCounts list =
    list
    |> List.distinct
    |> List.map (fun item -> item |> withSnd (list |> countItem item))

let mapAt i f list =
    list
    |> List.mapi (fun index item -> if index = i then item |> f else item)

let collectAt i f list =
    list
    |> List.mapi (fun index item -> if index = i then item |> f else [ item ])
    |> List.concat

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

let foldi folder seed list = list |> List.indexed |> List.fold folder seed

let hasDuplicates list = list |> List.distinct <> list

let tryFindIndexOf item list = list |> List.tryFindIndex ((=) item)

let splitAtItem item list =
    match list |> tryFindIndexOf item with
    | Some index -> list |> List.take index, list |> List.skip (index + 1)
    | None -> list, []

let tryToTuple =
    function
    | [ a; b ] -> Some(a, b)
    | _ -> None

let filterSplit pred list =
    (list |> List.filter pred, list |> List.filter (not << pred))

let filterMap pred f list =
    list
    |> List.map (fun item -> if pred item then f item else item)

let inline mult (list: list<'a>) =
    match list with
    | [] -> LanguagePrimitives.GenericZero<'a>
    | t ->
        let mutable acc = LanguagePrimitives.GenericOne<'a>

        for x in t do
            acc <- Checked.op_Multiply acc x

        acc

let sortByCount list =
    list
    |> List.distinct
    |> List.sortBy (fun item -> list |> countItem item)

let appendItem item list = list @ [ item ]
