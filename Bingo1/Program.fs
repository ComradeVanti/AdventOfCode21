module AdventOfCode21.Bingo1.Program

open System.IO
open AdventOfCode21.Bingo1.Parsing
open AdventOfCode21.Bingo1.Bingo

let play game inputNumbers =

    let rec playUntilDone game remainingInputs =
        let number = remainingInputs |> List.head
        let remaining = remainingInputs |> List.tail
        let progressed = game |> progress number

        match progressed |> tryFindWinner with
        | Some board -> board |> score number
        | None -> playUntilDone progressed remaining


    playUntilDone game inputNumbers

let private tryRunForFile path =
    try
        let lines = File.ReadAllLines path |> Array.toList
        let game = lines |> parseGame
        let inputNumbers = lines |> parseInputNumbers

        Ok(play game inputNumbers)
    with
    | e -> Error e.Message


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
