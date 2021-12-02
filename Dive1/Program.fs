module AdventOfCode21.Dive1.Program

open System.IO
open Submarine

let parseDirection s =
    if s = "forward" then Forward
    elif s = "up" then Up
    else Down

let parseCommand (s: string) =
    let parts = s.Split " "
    let direction = parts |> Array.item 0 |> parseDirection
    let distance = parts |> Array.item 1 |> int

    Move(direction, distance)

let private analyse commands =

    let start = initialSub
    let doCommand sub cmd = sub |> executeCommand cmd

    commands
    |> List.map parseCommand
    |> List.fold doCommand start
    |> multPos

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
