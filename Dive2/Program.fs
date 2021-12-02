module AdventOfCode21.Dive2.Program

open System.IO
open Submarine

let parseCommand (s: string) =
    let parts = s.Split " "
    let cmd = parts |> Array.item 0
    let distance = parts |> Array.item 1 |> int

    if cmd = "forward" then Move distance
    elif cmd = "up" then ChangeAim -distance
    else ChangeAim distance

let private analyse commands =

    let start = zeroSub
    let doCommand sub cmd = sub |> executeCmd cmd

    commands
    |> List.map parseCommand
    |> List.fold doCommand start
    |> multipliedPos

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
