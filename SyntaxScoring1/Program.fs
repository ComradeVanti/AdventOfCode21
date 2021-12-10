module AdventOfCode21.SonarSweep1.Program

open System
open AdventOfCode21
open AdventOfCode21.SyntaxScoring1.Nav
open AdventOfCode21.SyntaxScoring1.Parsing
open AdventOfCode21.SyntaxScoring1.NavSyntax

let tryParseInput args =
    res {
        let! path =
            args
            |> Array.tryItem 0
            |> Option.asResult "Invalid number of args"

        let! lines = IO.tryReadLines path

        return!
            lines
            |> tryParseInput
            |> Option.asResult "Could not parse input"
    }



let score =
    function
    | InvalidClose chunkType ->
        match chunkType with
        | Round -> 3
        | Square -> 57
        | Curly -> 1197
        | Angle -> 25137

[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map (List.map check)
    |> Result.map Result.collectErrors
    |> Result.map (List.map score)
    |> Result.map List.sum
    |> Console.printResult
