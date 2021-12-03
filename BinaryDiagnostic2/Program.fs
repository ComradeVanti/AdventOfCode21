module AdventOfCode21.BinaryDiagnostic2.Program

open System.IO
open DiagnosticReport
open Diagnostics

let private analyse lines = lines |> parseReport |> calcLifeSupportRating

let private tryRunForFile path =
    try
        File.ReadAllLines path |> Array.toList |> analyse |> Ok
    with
    | _ -> Error "Invalid path"


[<EntryPoint>]
let main args =
    let path = args |> Array.item 0

    path
    |> tryRunForFile
    |> function
        | Ok num ->
            printf "%d" num
            0
        | Error e ->
            printf "%s" e
            1
