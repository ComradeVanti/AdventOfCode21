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

let score dels =

    let addScore acc s = (acc * 5L) + s

    dels
    |> List.map
        (function
        | Round -> 1L
        | Square -> 2L
        | Curly -> 3L
        | Angle -> 4L)
    |> List.fold addScore 0L

[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map (List.filter isValid)
    |> Result.map (List.map genCompletion)
    |> Result.map (List.map score)
    |> Result.map List.median
    |> Console.printResult
