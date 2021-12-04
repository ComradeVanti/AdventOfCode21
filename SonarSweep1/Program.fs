module AdventOfCode21.SonarSweep1.Program

open System
open AdventOfCode21
open AdventOfCode21.SonarSweep1.Parsing
open AdventOfCode21.SonarSweep1.Sonar

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


[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map analyze
    |> Console.printResult
