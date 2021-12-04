module AdventOfCode21.SonarSweep

open System.IO


let private analyse windowSize numbers =
    numbers
    |> List.windowed windowSize
    |> List.map List.sum
    |> List.pairwise
    |> List.filter (fun (f, s) -> s > f)
    |> List.length

let private tryRunForFile windowSize path =
    try
        File.ReadAllLines path
        |> Array.toList
        |> List.map int
        |> analyse windowSize
        |> Ok
    with
    | _ -> Error "Invalid path"


[<EntryPoint>]
let main args =
    let path = args |> Array.item 0
    let windowSize = args |> Array.item 1 |> int

    path
    |> tryRunForFile windowSize
    |> function
        | Ok num ->
            printf "%d" num
            0
        | Error e ->
            printf "%s" e
            1
