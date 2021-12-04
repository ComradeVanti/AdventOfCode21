module AdventOfCode21.Bingo2.Program

open System.IO
open AdventOfCode21.Bingo2.Parsing
open AdventOfCode21.Bingo2.Bingo

let play game inputNumbers =

    let rec playUntilDone game remainingInputs =
        let number = remainingInputs |> List.head
        let remaining = remainingInputs |> List.tail
        let progressed = game |> progress number

        match progressed |> winners with
        | [ board ] when progressed |> boards |> List.length = 1 ->
            board |> score number
        | winners ->
            let nextGame =
                progressed |> boards |> List.except winners |> startGame

            playUntilDone nextGame remaining

    playUntilDone game inputNumbers

let private runForFile path =
    let lines = File.ReadAllLines path |> Array.toList
    let game = lines |> parseGame
    let inputNumbers = lines |> parseInputNumbers

    play game inputNumbers


[<EntryPoint>]
let main args =
    let path = args |> Array.item 0

    path |> runForFile |> (printf "%d")
    0
