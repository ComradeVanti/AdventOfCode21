module AdventOfCode21.SonarSweep1.Program

open System
open AdventOfCode21
open AdventOfCode21.Parsing
open AdventOfCode21.SonarSweep1.Parsing
open AdventOfCode21.SonarSweep1.Sonar

let tryParseInput args =
    res {
        let! readings =
            args
            |> Array.tryItem 0
            |> Option.asResult "Invalid number of args"
            |> Result.bind IO.tryReadLines
            |> Result.bindOption tryParseInput "Could not parse readings"

        let! windowSize =
            args
            |> Array.tryItem 1
            |> Option.asResult "Missing parameter \"Window size\""
            |> Result.bindOption tryParseInt "Could not parse window-size"

        return readings, windowSize
    }


[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map analyze
    |> Console.printResult
